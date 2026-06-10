Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Windows.Forms
Imports PLCcomModbus.Core.Security

Friend NotInheritable Class CertificateManagerForm
    Inherits Form

    Private ReadOnly pkiStore As SecureModbusPkiStore
    Private ReadOnly entries As New List(Of CertificateEntry)()
    Private listViewCertificates As ListView
    Private textBoxDetails As RichTextBox
    Private buttonTrust As Button
    Private buttonTrustIssuer As Button
    Private buttonReject As Button
    Private buttonDelete As Button
    Private buttonRefresh As Button
    Private buttonOpenPki As Button
    Private buttonEnsureOwn As Button
    Private buttonClose As Button
    Private labelPkiPath As Label
    Private labelStatus As Label
    Private certificateContextMenu As ContextMenuStrip
    Private menuTrust As ToolStripMenuItem
    Private menuTrustIssuer As ToolStripMenuItem
    Private menuReject As ToolStripMenuItem
    Private menuDelete As ToolStripMenuItem
    Private menuOpenFolder As ToolStripMenuItem
    Private menuCopyThumbprint As ToolStripMenuItem
    Private menuRefresh As ToolStripMenuItem
    Private storeImages As ImageList
    Private buttonToolTip As ToolTip
    Private ReadOnly resources As System.Resources.ResourceManager

    Friend Sub New()
        pkiStore = SecureTcpExampleOptions.CreatePkiStore()
        resources = New System.Resources.ResourceManager(Me.GetType().Namespace + ".Resources", Me.GetType().Assembly)
        InitializeComponent()
        LoadEntries()
    End Sub

    Private Sub InitializeComponent()
        Text = R("CertificateManagerForm_Text", "SecureTCP Certificate Manager")
        StartPosition = FormStartPosition.CenterParent
        ClientSize = New Size(980, 620)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = SystemIcons.Shield
        MaximizeBox = False
        MinimizeBox = False
        Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        Dim headerPanel As New Panel()
        headerPanel.BackColor = Color.FromArgb(245, 248, 252)
        headerPanel.Location = New Point(0, 0)
        headerPanel.Size = New Size(ClientSize.Width, 84)

        Dim pictureBox As New PictureBox()
        pictureBox.Location = New Point(18, 18)
        pictureBox.Size = New Size(40, 40)
        pictureBox.SizeMode = PictureBoxSizeMode.CenterImage
        pictureBox.Image = SystemIcons.Shield.ToBitmap()

        Dim labelTitle As New Label()
        labelTitle.AutoSize = False
        labelTitle.Font = New Font(Font, FontStyle.Bold)
        labelTitle.Location = New Point(70, 14)
        labelTitle.Size = New Size(880, 22)
        labelTitle.Text = R("CertificateManager_Title_Text", "SecureTCP PKI store")

        labelPkiPath = New Label()
        labelPkiPath.AutoEllipsis = True
        labelPkiPath.Location = New Point(70, 36)
        labelPkiPath.Size = New Size(880, 18)
        labelPkiPath.Text = pkiStore.BasePath

        labelStatus = New Label()
        labelStatus.AutoEllipsis = True
        labelStatus.Location = New Point(70, 58)
        labelStatus.Size = New Size(880, 18)
        labelStatus.Text = R("CertificateManager_Loading_Text", "Loading certificates...")

        headerPanel.Controls.Add(pictureBox)
        headerPanel.Controls.Add(labelTitle)
        headerPanel.Controls.Add(labelPkiPath)
        headerPanel.Controls.Add(labelStatus)

        storeImages = New ImageList()
        storeImages.ColorDepth = ColorDepth.Depth32Bit
        storeImages.ImageSize = New Size(16, 16)
        storeImages.Images.Add("Own", SystemIcons.Application.ToBitmap())
        storeImages.Images.Add("Trusted", SystemIcons.Shield.ToBitmap())
        storeImages.Images.Add("Issuers", SystemIcons.Information.ToBitmap())
        storeImages.Images.Add("Rejected", SystemIcons.Warning.ToBitmap())
        storeImages.Images.Add("Error", SystemIcons.Error.ToBitmap())

        listViewCertificates = New ListView()
        listViewCertificates.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        listViewCertificates.FullRowSelect = True
        listViewCertificates.GridLines = False
        listViewCertificates.HeaderStyle = ColumnHeaderStyle.Nonclickable
        listViewCertificates.HideSelection = False
        listViewCertificates.MultiSelect = False
        listViewCertificates.View = View.Details
        listViewCertificates.SmallImageList = storeImages
        listViewCertificates.Location = New Point(16, 98)
        listViewCertificates.Size = New Size(948, 300)
        listViewCertificates.Columns.Add(R("CertificateManager_ColumnStore_Text", "Store"))
        listViewCertificates.Columns.Add(R("CertificateManager_ColumnStatus_Text", "Status"))
        listViewCertificates.Columns.Add(R("CertificateManager_ColumnFile_Text", "File"))
        listViewCertificates.Columns.Add(R("CertificateManager_ColumnSubject_Text", "Subject"))
        listViewCertificates.Columns.Add(R("CertificateManager_ColumnIssuer_Text", "Issuer"))
        listViewCertificates.Columns.Add(R("CertificateManager_ColumnValidTo_Text", "Valid to"))
        listViewCertificates.Columns.Add(R("CertificateManager_ColumnRole_Text", "Role"))
        AddHandler listViewCertificates.SelectedIndexChanged, AddressOf listViewCertificates_SelectedIndexChanged
        AddHandler listViewCertificates.MouseDown, AddressOf listViewCertificates_MouseDown
        AddHandler listViewCertificates.MouseDoubleClick, AddressOf listViewCertificates_MouseDoubleClick
        FitCertificateColumns()

        certificateContextMenu = New ContextMenuStrip()
        menuTrust = New ToolStripMenuItem(R("CertificateManager_MenuTrust_Text", "Trust certificate"), Nothing, AddressOf menuTrust_Click)
        menuTrustIssuer = New ToolStripMenuItem(R("CertificateManager_MenuTrustIssuer_Text", "Trust as issuer"), Nothing, AddressOf menuTrustIssuer_Click)
        menuReject = New ToolStripMenuItem(R("CertificateManager_MenuReject_Text", "Reject certificate"), Nothing, AddressOf menuReject_Click)
        menuDelete = New ToolStripMenuItem(R("CertificateManager_MenuDelete_Text", "Delete file"), Nothing, AddressOf menuDelete_Click)
        menuOpenFolder = New ToolStripMenuItem(R("CertificateManager_MenuOpenFolder_Text", "Open containing folder"), Nothing, AddressOf menuOpenFolder_Click)
        menuCopyThumbprint = New ToolStripMenuItem(R("CertificateManager_MenuCopyThumbprint_Text", "Copy thumbprint"), Nothing, AddressOf menuCopyThumbprint_Click)
        menuRefresh = New ToolStripMenuItem(R("CertificateManager_MenuRefresh_Text", "Refresh"), Nothing, AddressOf menuRefresh_Click)
        certificateContextMenu.Items.AddRange(New ToolStripItem() {
            menuTrust,
            menuTrustIssuer,
            menuReject,
            New ToolStripSeparator(),
            menuCopyThumbprint,
            menuOpenFolder,
            New ToolStripSeparator(),
            menuDelete,
            menuRefresh})
        AddHandler certificateContextMenu.Opening, AddressOf contextMenu_Opening
        listViewCertificates.ContextMenuStrip = certificateContextMenu

        Dim detailsGroup As New GroupBox()
        detailsGroup.Location = New Point(16, 414)
        detailsGroup.Size = New Size(948, 100)
        detailsGroup.Text = R("CertificateManager_DetailsGroup_Text", "Certificate details")

        textBoxDetails = New RichTextBox()
        textBoxDetails.BorderStyle = BorderStyle.None
        textBoxDetails.Location = New Point(12, 22)
        textBoxDetails.Multiline = True
        textBoxDetails.ReadOnly = True
        textBoxDetails.ScrollBars = RichTextBoxScrollBars.Vertical
        textBoxDetails.Size = New Size(924, 64)
        textBoxDetails.BackColor = SystemColors.Window
        detailsGroup.Controls.Add(textBoxDetails)

        Dim footerPanel As New Panel()
        footerPanel.BackColor = Color.FromArgb(248, 248, 248)
        footerPanel.Location = New Point(0, 532)
        footerPanel.Size = New Size(ClientSize.Width, 88)
        Dim separator As New Panel()
        separator.BackColor = Color.Gainsboro
        separator.Location = New Point(0, 0)
        separator.Size = New Size(ClientSize.Width, 1)
        footerPanel.Controls.Add(separator)

        buttonToolTip = New ToolTip()
        buttonEnsureOwn = CreateFooterButton(R("CertificateManager_ButtonOwn_Text", "Own"), 16, AddressOf buttonEnsureOwn_Click, CreateOwnCertificateImage(), R("CertificateManager_ButtonOwn_ToolTip", "Create or load the own SecureTCP certificate."))
        buttonOpenPki = CreateFooterButton(R("CertificateManager_ButtonOpenPki_Text", "PKI"), 94, AddressOf buttonOpenPki_Click, CreateOpenPkiImage(), R("CertificateManager_ButtonOpenPki_ToolTip", "Open the SecureTCP PKI folder."))
        buttonRefresh = CreateFooterButton(R("CertificateManager_ButtonRefresh_Text", "Refresh"), 172, AddressOf buttonRefresh_Click, CreateRefreshImage(), R("CertificateManager_ButtonRefresh_ToolTip", "Refresh the certificate list."))
        buttonTrust = CreateFooterButton(R("CertificateManager_ButtonTrust_Text", "Trust"), 440, AddressOf buttonTrust_Click, CreateTrustImage(), R("CertificateManager_ButtonTrust_ToolTip", "Move the selected rejected certificate to trusted."))
        buttonTrustIssuer = CreateFooterButton(R("CertificateManager_ButtonIssuer_Text", "Issuer"), 518, AddressOf buttonTrustIssuer_Click, CreateIssuerImage(), R("CertificateManager_ButtonIssuer_ToolTip", "Move the selected certificate to issuers."))
        buttonReject = CreateFooterButton(R("CertificateManager_ButtonReject_Text", "Reject"), 596, AddressOf buttonReject_Click, CreateRejectImage(), R("CertificateManager_ButtonReject_ToolTip", "Move the selected certificate to rejected."))
        buttonDelete = CreateFooterButton(R("CertificateManager_ButtonDelete_Text", "Delete"), 674, AddressOf buttonDelete_Click, CreateDeleteImage(), R("CertificateManager_ButtonDelete_ToolTip", "Delete the selected certificate file."))
        buttonClose = CreateFooterButton(R("CertificateManager_ButtonClose_Text", "close" & vbCrLf & "window"), 896, AddressOf buttonClose_Click, GetCloseButtonImage(), R("CertificateManager_ButtonClose_ToolTip", "Close this window."))
        buttonClose.DialogResult = DialogResult.Cancel
        CancelButton = buttonClose

        footerPanel.Controls.Add(buttonEnsureOwn)
        footerPanel.Controls.Add(buttonOpenPki)
        footerPanel.Controls.Add(buttonRefresh)
        footerPanel.Controls.Add(buttonTrust)
        footerPanel.Controls.Add(buttonTrustIssuer)
        footerPanel.Controls.Add(buttonReject)
        footerPanel.Controls.Add(buttonDelete)
        footerPanel.Controls.Add(buttonClose)

        Controls.Add(headerPanel)
        Controls.Add(listViewCertificates)
        Controls.Add(detailsGroup)
        Controls.Add(footerPanel)
    End Sub

    Private Function R(name As String, fallback As String) As String
        Dim value As String = resources.GetString(name)
        If String.IsNullOrEmpty(value) Then
            Return fallback
        End If

        Return value
    End Function

    Private Function GetStoreText(storeName As String) As String
        Select Case storeName
            Case "Own"
                Return R("CertificateManager_StoreOwn_Text", "Own")
            Case "Trusted"
                Return R("CertificateManager_StoreTrusted_Text", "Trusted")
            Case "Issuers"
                Return R("CertificateManager_StoreIssuers_Text", "Issuers")
            Case "Rejected"
                Return R("CertificateManager_StoreRejected_Text", "Rejected")
            Case Else
                Return storeName
        End Select
    End Function

    Private Function GetStatusText(entry As CertificateEntry) As String
        If entry.Certificate Is Nothing Then
            Return R("CertificateManager_StatusLoadError_Text", "Load error")
        End If
        If DateTime.Now < entry.Certificate.NotBefore Then
            Return R("CertificateManager_StatusNotYetValid_Text", "Not yet valid")
        End If
        If DateTime.Now > entry.Certificate.NotAfter Then
            Return R("CertificateManager_StatusExpired_Text", "Expired")
        End If
        Return R("CertificateManager_StatusValid_Text", "Valid")
    End Function

    Private Function CreateFooterButton(text As String, left As Integer, clickHandler As EventHandler, image As Image, toolTipText As String) As Button
        Dim button As New Button()
        button.AutoSize = False
        button.Font = Font
        button.Image = image
        button.ImageAlign = ContentAlignment.TopCenter
        button.Location = New Point(left, 10)
        button.MinimumSize = New Size(68, 68)
        button.MaximumSize = New Size(68, 68)
        button.Padding = New Padding(2, 4, 2, 3)
        button.Size = New Size(68, 68)
        button.Text = text
        button.TextAlign = ContentAlignment.BottomCenter
        button.TextImageRelation = TextImageRelation.ImageAboveText
        button.UseVisualStyleBackColor = True
        AddHandler button.Click, clickHandler
        buttonToolTip.SetToolTip(button, toolTipText)
        Return button
    End Function

    Private Shared Function CreateOwnCertificateImage() As Image
        Dim bitmap As Bitmap = CreateIconBitmap()
        Using graphics As Graphics = Graphics.FromImage(bitmap)
            PrepareIconGraphics(graphics)
            Using paperBrush As New SolidBrush(Color.FromArgb(255, 248, 220)), borderPen As New Pen(Color.FromArgb(148, 126, 70), 1.4F), sealBrush As New SolidBrush(Color.FromArgb(64, 132, 206)), keyPen As New Pen(Color.FromArgb(88, 88, 88), 2.0F)
                graphics.FillRectangle(paperBrush, 6, 3, 17, 23)
                graphics.DrawRectangle(borderPen, 6, 3, 17, 23)
                graphics.FillEllipse(sealBrush, 17, 17, 8, 8)
                graphics.DrawEllipse(keyPen, 7, 20, 6, 6)
                graphics.DrawLine(keyPen, 13, 23, 25, 23)
                graphics.DrawLine(keyPen, 21, 23, 21, 27)
            End Using
        End Using

        Return bitmap
    End Function

    Private Shared Function CreateOpenPkiImage() As Image
        Dim bitmap As Bitmap = CreateIconBitmap()
        Using graphics As Graphics = Graphics.FromImage(bitmap)
            PrepareIconGraphics(graphics)
            Using tabBrush As New SolidBrush(Color.FromArgb(245, 196, 72)), folderBrush As New SolidBrush(Color.FromArgb(255, 214, 93)), borderPen As New Pen(Color.FromArgb(163, 125, 42), 1.3F)
                graphics.FillRectangle(tabBrush, 4, 8, 10, 5)
                graphics.FillRectangle(folderBrush, 4, 12, 24, 14)
                graphics.DrawRectangle(borderPen, 4, 8, 10, 5)
                graphics.DrawRectangle(borderPen, 4, 12, 24, 14)
            End Using
        End Using

        Return bitmap
    End Function

    Private Shared Function CreateRefreshImage() As Image
        Dim bitmap As Bitmap = CreateIconBitmap()
        Using graphics As Graphics = Graphics.FromImage(bitmap)
            PrepareIconGraphics(graphics)
            Using arrowPen As New Pen(Color.FromArgb(44, 112, 176), 2.4F), arrowBrush As New SolidBrush(Color.FromArgb(44, 112, 176))
                arrowPen.StartCap = LineCap.Round
                arrowPen.EndCap = LineCap.Round
                graphics.DrawArc(arrowPen, 6, 6, 20, 20, 35, 260)
                graphics.FillPolygon(arrowBrush, New Point() {New Point(24, 7), New Point(29, 8), New Point(26, 13)})
            End Using
        End Using

        Return bitmap
    End Function

    Private Shared Function CreateTrustImage() As Image
        Dim bitmap As Bitmap = CreateIconBitmap()
        Using graphics As Graphics = Graphics.FromImage(bitmap)
            PrepareIconGraphics(graphics)
            Using shieldBrush As New SolidBrush(Color.FromArgb(47, 150, 82)), checkPen As New Pen(Color.White, 3.0F)
                graphics.FillPolygon(shieldBrush, CreateShieldPoints())
                checkPen.StartCap = LineCap.Round
                checkPen.EndCap = LineCap.Round
                graphics.DrawLines(checkPen, New Point() {New Point(9, 17), New Point(14, 22), New Point(24, 11)})
            End Using
        End Using

        Return bitmap
    End Function

    Private Shared Function CreateIssuerImage() As Image
        Dim bitmap As Bitmap = CreateIconBitmap()
        Using graphics As Graphics = Graphics.FromImage(bitmap)
            PrepareIconGraphics(graphics)
            Using paperBrush As New SolidBrush(Color.White), borderPen As New Pen(Color.FromArgb(78, 126, 176), 1.4F), sealBrush As New SolidBrush(Color.FromArgb(64, 132, 206)), linePen As New Pen(Color.FromArgb(145, 160, 178), 1.3F)
                graphics.FillRectangle(paperBrush, 7, 4, 18, 23)
                graphics.DrawRectangle(borderPen, 7, 4, 18, 23)
                graphics.DrawLine(linePen, 11, 10, 21, 10)
                graphics.DrawLine(linePen, 11, 14, 21, 14)
                graphics.FillEllipse(sealBrush, 12, 17, 8, 8)
            End Using
        End Using

        Return bitmap
    End Function

    Private Shared Function CreateRejectImage() As Image
        Dim bitmap As Bitmap = CreateIconBitmap()
        Using graphics As Graphics = Graphics.FromImage(bitmap)
            PrepareIconGraphics(graphics)
            Using rejectBrush As New SolidBrush(Color.FromArgb(198, 57, 57)), linePen As New Pen(Color.White, 3.4F)
                graphics.FillEllipse(rejectBrush, 5, 5, 22, 22)
                linePen.StartCap = LineCap.Round
                linePen.EndCap = LineCap.Round
                graphics.DrawLine(linePen, 10, 16, 22, 16)
            End Using
        End Using

        Return bitmap
    End Function

    Private Shared Function CreateDeleteImage() As Image
        Dim bitmap As Bitmap = CreateIconBitmap()
        Using graphics As Graphics = Graphics.FromImage(bitmap)
            PrepareIconGraphics(graphics)
            Using binBrush As New SolidBrush(Color.FromArgb(118, 126, 135)), borderPen As New Pen(Color.FromArgb(80, 88, 96), 1.4F), xPen As New Pen(Color.FromArgb(205, 58, 58), 2.2F)
                graphics.FillRectangle(binBrush, 10, 12, 13, 15)
                graphics.DrawRectangle(borderPen, 10, 12, 13, 15)
                graphics.DrawLine(borderPen, 8, 10, 25, 10)
                graphics.DrawLine(borderPen, 13, 7, 20, 7)
                graphics.DrawLine(xPen, 13, 16, 20, 23)
                graphics.DrawLine(xPen, 20, 16, 13, 23)
            End Using
        End Using

        Return bitmap
    End Function

    Private Shared Function CreateIconBitmap() As Bitmap
        Dim bitmap As New Bitmap(32, 32)
        bitmap.MakeTransparent()
        Return bitmap
    End Function

    Private Shared Sub PrepareIconGraphics(graphics As Graphics)
        graphics.Clear(Color.Transparent)
        graphics.SmoothingMode = SmoothingMode.AntiAlias
    End Sub

    Private Shared Function CreateShieldPoints() As Point()
        Return New Point() {
            New Point(16, 3),
            New Point(27, 8),
            New Point(25, 20),
            New Point(16, 29),
            New Point(7, 20),
            New Point(5, 8)}
    End Function

    Private Sub FitCertificateColumns()
        Dim availableWidth As Integer = listViewCertificates.ClientSize.Width - 4
        If entries.Count > 8 Then
            availableWidth -= SystemInformation.VerticalScrollBarWidth
        End If

        Dim fixedWidths As Integer() = New Integer() {78, 80, 150, 245, 205, 80}
        Dim usedWidth As Integer = 0
        For index As Integer = 0 To fixedWidths.Length - 1
            listViewCertificates.Columns(index).Width = fixedWidths(index)
            usedWidth += fixedWidths(index)
        Next

        listViewCertificates.Columns(6).Width = Math.Max(70, availableWidth - usedWidth)
    End Sub

    Private Sub LoadEntries()
        pkiStore.EnsureDirectories()
        entries.Clear()
        AddEntries("Own", pkiStore.OwnCertificatesPath)
        AddEntries("Trusted", pkiStore.TrustedCertificatesPath)
        AddEntries("Issuers", pkiStore.IssuerCertificatesPath)
        AddEntries("Rejected", pkiStore.RejectedCertificatesPath)

        listViewCertificates.BeginUpdate()
        Try
            listViewCertificates.Items.Clear()
            For Each entry As CertificateEntry In entries
                Dim item As New ListViewItem(GetStoreText(entry.StoreName))
                item.ImageKey = If(entry.Certificate Is Nothing, "Error", entry.StoreName)
                item.SubItems.Add(GetStatusText(entry))
                item.SubItems.Add(Path.GetFileName(entry.FilePath))
                item.SubItems.Add(If(entry.Certificate Is Nothing, R("CertificateManager_NotLoaded_Text", "<not loaded>"), entry.Certificate.Subject))
                item.SubItems.Add(If(entry.Certificate Is Nothing, String.Empty, entry.Certificate.Issuer))
                item.SubItems.Add(If(entry.Certificate Is Nothing, String.Empty, entry.Certificate.NotAfter.ToString("yyyy-MM-dd")))
                item.SubItems.Add(If(entry.Certificate Is Nothing, String.Empty, GetRoleName(entry.Certificate)))
                item.Tag = entry
                ApplyItemStyle(item, entry)
                listViewCertificates.Items.Add(item)
            Next
        Finally
            listViewCertificates.EndUpdate()
        End Try

        FitCertificateColumns()
        UpdateStoreStatus()
        UpdateSelectionState()
    End Sub

    Private Shared Sub ApplyItemStyle(item As ListViewItem, entry As CertificateEntry)
        If entry.Certificate Is Nothing Then
            item.ForeColor = Color.Firebrick
            item.BackColor = Color.MistyRose
        ElseIf Not entry.IsDateValid Then
            item.ForeColor = Color.DarkOrange
            item.BackColor = Color.FromArgb(255, 248, 220)
        ElseIf entry.StoreName = "Rejected" Then
            item.BackColor = Color.FromArgb(255, 238, 238)
        ElseIf entry.StoreName = "Trusted" OrElse entry.StoreName = "Issuers" Then
            item.BackColor = Color.FromArgb(240, 250, 240)
        End If
    End Sub

    Private Sub AddEntries(storeName As String, directoryPath As String)
        If Not Directory.Exists(directoryPath) Then
            Return
        End If

        For Each filePath As String In Directory.GetFiles(directoryPath)
            If Not HasCertificateExtension(filePath) Then
                Continue For
            End If

            Try
                Dim certificates As X509Certificate2Collection = LoadCertificatesFromFile(filePath)
                If certificates.Count = 0 Then
                    entries.Add(CertificateEntry.FromError(storeName, filePath, R("CertificateManager_ErrorNoCertificate_Text", "The file does not contain a certificate.")))
                End If

                For Each certificate As X509Certificate2 In certificates
                    entries.Add(New CertificateEntry(storeName, filePath, certificate, Nothing))
                Next
            Catch ex As Exception
                entries.Add(CertificateEntry.FromError(storeName, filePath, ex.Message))
            End Try
        Next
    End Sub

    Private Sub UpdateStoreStatus()
        Dim own As Integer = CountEntries("Own")
        Dim trusted As Integer = CountEntries("Trusted")
        Dim issuers As Integer = CountEntries("Issuers")
        Dim rejected As Integer = CountEntries("Rejected")
        labelStatus.Text = String.Format(R("CertificateManager_StatusCounts_Text", "Own: {0}    Trusted: {1}    Issuers: {2}    Rejected: {3}"), own, trusted, issuers, rejected)
        labelStatus.ForeColor = If(rejected > 0, Color.Firebrick, Color.DarkGreen)
    End Sub

    Private Function CountEntries(storeName As String) As Integer
        Dim count As Integer = 0
        For Each entry As CertificateEntry In entries
            If entry.StoreName = storeName Then
                count += 1
            End If
        Next

        Return count
    End Function

    Private Sub UpdateSelectionState()
        Dim entry As CertificateEntry = SelectedEntry
        Dim hasCertificate As Boolean = entry IsNot Nothing AndAlso entry.Certificate IsNot Nothing
        Dim canTrust As Boolean = hasCertificate AndAlso entry.StoreName = "Rejected"
        Dim canReject As Boolean = hasCertificate AndAlso entry.StoreName <> "Rejected" AndAlso entry.StoreName <> "Own"
        Dim canTrustIssuer As Boolean = hasCertificate AndAlso entry.StoreName <> "Issuers" AndAlso entry.StoreName <> "Own"
        buttonTrust.Enabled = canTrust
        buttonTrustIssuer.Enabled = canTrustIssuer
        buttonReject.Enabled = canReject
        buttonDelete.Enabled = entry IsNot Nothing

        If entry Is Nothing Then
            textBoxDetails.Text = R("CertificateManager_SelectCertificate_Text", "Select a certificate to see its details. Use the context menu to trust, reject, delete, or inspect certificate files.")
            Return
        End If

        textBoxDetails.Text = BuildDetails(entry)
    End Sub

    Private ReadOnly Property SelectedEntry As CertificateEntry
        Get
            If listViewCertificates.SelectedItems.Count = 0 Then
                Return Nothing
            End If

            Return TryCast(listViewCertificates.SelectedItems(0).Tag, CertificateEntry)
        End Get
    End Property

    Private Function BuildDetails(entry As CertificateEntry) As String
        Dim builder As New StringBuilder()
        builder.AppendLine(R("CertificateManager_DetailStore_Text", "Store:") & " " & GetStoreText(entry.StoreName))
        builder.AppendLine(R("CertificateManager_DetailStatus_Text", "Status:") & " " & GetStatusText(entry))
        builder.AppendLine(R("CertificateManager_DetailFile_Text", "File:") & " " & entry.FilePath)
        If entry.Certificate Is Nothing Then
            builder.AppendLine(R("CertificateManager_DetailLoadError_Text", "Load error:") & " " & entry.LoadError)
            Return builder.ToString()
        End If

        builder.AppendLine(R("CertificateManager_DetailSubject_Text", "Subject:") & " " & entry.Certificate.Subject)
        builder.AppendLine(R("CertificateManager_DetailIssuer_Text", "Issuer:") & " " & entry.Certificate.Issuer)
        builder.AppendLine(R("CertificateManager_DetailThumbprint_Text", "Thumbprint:") & " " & entry.Certificate.Thumbprint)
        builder.AppendLine(R("CertificateManager_DetailSerial_Text", "Serial:") & " " & entry.Certificate.SerialNumber)
        builder.AppendLine(R("CertificateManager_DetailValidFrom_Text", "Valid from:") & " " & entry.Certificate.NotBefore.ToString("yyyy-MM-dd HH:mm:ss"))
        builder.AppendLine(R("CertificateManager_DetailValidTo_Text", "Valid to:") & " " & entry.Certificate.NotAfter.ToString("yyyy-MM-dd HH:mm:ss"))
        builder.AppendLine(R("CertificateManager_DetailRole_Text", "Role:") & " " & GetRoleName(entry.Certificate))
        builder.AppendLine(R("CertificateManager_DetailPrivateKey_Text", "Private key:") & " " & If(entry.Certificate.HasPrivateKey, R("CertificateManager_Yes_Text", "yes"), R("CertificateManager_No_Text", "no")))
        Return builder.ToString()
    End Function

    Private Sub listViewCertificates_SelectedIndexChanged(sender As Object, e As EventArgs)
        UpdateSelectionState()
    End Sub

    Private Sub listViewCertificates_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button <> MouseButtons.Right Then
            Return
        End If

        Dim item As ListViewItem = listViewCertificates.GetItemAt(e.X, e.Y)
        If item Is Nothing Then
            Return
        End If

        item.Selected = True
        item.Focused = True
    End Sub

    Private Sub listViewCertificates_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        Dim entry As CertificateEntry = SelectedEntry
        If entry IsNot Nothing Then
            MessageBox.Show(BuildDetails(entry), Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub contextMenu_Opening(sender As Object, e As CancelEventArgs)
        UpdateSelectionState()
        Dim entry As CertificateEntry = SelectedEntry
        Dim hasCertificate As Boolean = entry IsNot Nothing AndAlso entry.Certificate IsNot Nothing
        menuTrust.Enabled = hasCertificate AndAlso entry.StoreName = "Rejected"
        menuTrustIssuer.Enabled = hasCertificate AndAlso entry.StoreName <> "Issuers" AndAlso entry.StoreName <> "Own"
        menuReject.Enabled = hasCertificate AndAlso entry.StoreName <> "Rejected" AndAlso entry.StoreName <> "Own"
        menuDelete.Enabled = entry IsNot Nothing
        menuCopyThumbprint.Enabled = hasCertificate
        menuOpenFolder.Enabled = entry IsNot Nothing
    End Sub

    Private Sub buttonEnsureOwn_Click(sender As Object, e As EventArgs)
        Try
            Dim certificate As X509Certificate2 = SecureTcpExampleOptions.EnsureOwnCertificate()
            MessageBox.Show(R("CertificateManager_OwnCertificateAvailable_Text", "Own certificate is available:") & Environment.NewLine & certificate.Subject, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadEntries()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub buttonTrust_Click(sender As Object, e As EventArgs)
        MoveSelectedCertificate(SecureModbusPkiStoreKind.Trusted)
    End Sub

    Private Sub buttonTrustIssuer_Click(sender As Object, e As EventArgs)
        MoveSelectedCertificate(SecureModbusPkiStoreKind.Issuer)
    End Sub

    Private Sub buttonReject_Click(sender As Object, e As EventArgs)
        MoveSelectedCertificate(SecureModbusPkiStoreKind.Rejected)
    End Sub

    Private Sub menuTrust_Click(sender As Object, e As EventArgs)
        MoveSelectedCertificate(SecureModbusPkiStoreKind.Trusted)
    End Sub

    Private Sub menuTrustIssuer_Click(sender As Object, e As EventArgs)
        MoveSelectedCertificate(SecureModbusPkiStoreKind.Issuer)
    End Sub

    Private Sub menuReject_Click(sender As Object, e As EventArgs)
        MoveSelectedCertificate(SecureModbusPkiStoreKind.Rejected)
    End Sub

    Private Sub MoveSelectedCertificate(targetStoreKind As SecureModbusPkiStoreKind)
        Dim entry As CertificateEntry = SelectedEntry
        If entry Is Nothing OrElse entry.Certificate Is Nothing Then
            Return
        End If

        Try
            Dim targetDirectory As String
            Dim targetStoreName As String
            Dim targetPath As String
            Select Case targetStoreKind
                Case SecureModbusPkiStoreKind.Trusted
                    targetDirectory = pkiStore.TrustedCertificatesPath
                    targetStoreName = "Trusted"
                    targetPath = pkiStore.StoreTrustedCertificate(entry.Certificate)
                Case SecureModbusPkiStoreKind.Issuer
                    targetDirectory = pkiStore.IssuerCertificatesPath
                    targetStoreName = "Issuers"
                    targetPath = pkiStore.StoreIssuerCertificate(entry.Certificate)
                Case SecureModbusPkiStoreKind.Rejected
                    targetDirectory = pkiStore.RejectedCertificatesPath
                    targetStoreName = "Rejected"
                    targetPath = pkiStore.StoreRejectedCertificate(entry.Certificate)
                Case Else
                    Return
            End Select

            DeleteSourceFileIfItIsInPki(entry.FilePath, targetDirectory)
            MessageBox.Show(String.Format(R("CertificateManager_CertificateMoved_Text", "Certificate moved to {0}."), GetStoreText(targetStoreName)) & Environment.NewLine & targetPath, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadEntries()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub buttonDelete_Click(sender As Object, e As EventArgs)
        DeleteSelectedCertificate()
    End Sub

    Private Sub menuDelete_Click(sender As Object, e As EventArgs)
        DeleteSelectedCertificate()
    End Sub

    Private Sub DeleteSelectedCertificate()
        Dim entry As CertificateEntry = SelectedEntry
        If entry Is Nothing Then
            Return
        End If

        If MessageBox.Show(R("CertificateManager_DeleteQuestion_Text", "Delete certificate file?") & Environment.NewLine & entry.FilePath, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If

        Try
            DeleteSourceFileIfItIsInPki(entry.FilePath, Nothing)
            LoadEntries()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub buttonRefresh_Click(sender As Object, e As EventArgs)
        LoadEntries()
    End Sub

    Private Sub menuRefresh_Click(sender As Object, e As EventArgs)
        LoadEntries()
    End Sub

    Private Sub buttonClose_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Shared Function GetCloseButtonImage() As Image
        Try
            Dim resources As New ComponentResourceManager(GetType(main))
            Return TryCast(resources.GetObject("btnClose.Image"), Image)
        Catch
            Return SystemIcons.Error.ToBitmap()
        End Try
    End Function

    Private Sub buttonOpenPki_Click(sender As Object, e As EventArgs)
        OpenFolder(pkiStore.BasePath)
    End Sub

    Private Sub menuOpenFolder_Click(sender As Object, e As EventArgs)
        Dim entry As CertificateEntry = SelectedEntry
        If entry Is Nothing Then
            Return
        End If

        OpenFolder(Path.GetDirectoryName(entry.FilePath))
    End Sub

    Private Sub menuCopyThumbprint_Click(sender As Object, e As EventArgs)
        Dim entry As CertificateEntry = SelectedEntry
        If entry Is Nothing OrElse entry.Certificate Is Nothing OrElse String.IsNullOrWhiteSpace(entry.Certificate.Thumbprint) Then
            Return
        End If

        Clipboard.SetText(entry.Certificate.Thumbprint, TextDataFormat.Text)
    End Sub

    Private Sub OpenFolder(folder As String)
        Try
            pkiStore.EnsureDirectories()
            Process.Start(New ProcessStartInfo(folder) With {.UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub DeleteSourceFileIfItIsInPki(filePath As String, targetDirectory As String)
        If String.IsNullOrWhiteSpace(filePath) OrElse Not File.Exists(filePath) Then
            Return
        End If

        Dim fullPath As String = Path.GetFullPath(filePath)
        Dim pkiBasePath As String = Path.GetFullPath(pkiStore.BasePath).TrimEnd(Path.DirectorySeparatorChar) & Path.DirectorySeparatorChar
        If Not fullPath.StartsWith(pkiBasePath, StringComparison.OrdinalIgnoreCase) Then
            Throw New InvalidOperationException(R("CertificateManager_ErrorOutsidePki_Text", "Refusing to delete a file outside the PKI store:") & " " & fullPath)
        End If

        If Not String.IsNullOrWhiteSpace(targetDirectory) Then
            Dim sourceDirectory As String = Path.GetFullPath(Path.GetDirectoryName(fullPath)).TrimEnd(Path.DirectorySeparatorChar)
            Dim normalizedTargetDirectory As String = Path.GetFullPath(targetDirectory).TrimEnd(Path.DirectorySeparatorChar)
            If String.Equals(sourceDirectory, normalizedTargetDirectory, StringComparison.OrdinalIgnoreCase) Then
                Return
            End If
        End If

        File.Delete(fullPath)
    End Sub

    Private Shared Function HasCertificateExtension(fileName As String) As Boolean
        Dim extension As String = Path.GetExtension(fileName)
        Return String.Equals(extension, ".der", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".cer", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".cert", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".crt", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".pem", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".pfx", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(extension, ".p12", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Shared Function LoadCertificatesFromFile(fileName As String) As X509Certificate2Collection
        Dim extension As String = Path.GetExtension(fileName)
        If String.Equals(extension, ".pfx", StringComparison.OrdinalIgnoreCase) OrElse
           String.Equals(extension, ".p12", StringComparison.OrdinalIgnoreCase) Then
            Dim collection As New X509Certificate2Collection()
            collection.Import(File.ReadAllBytes(fileName), String.Empty, X509KeyStorageFlags.Exportable)
            Return collection
        End If

        Dim text As String = TryReadText(fileName)
        If text IsNot Nothing AndAlso text.IndexOf("-----BEGIN CERTIFICATE-----", StringComparison.Ordinal) >= 0 Then
            Return LoadPemCertificates(text)
        End If

        Dim result As New X509Certificate2Collection()
        result.Add(New X509Certificate2(fileName))
        Return result
    End Function

    Private Shared Function LoadPemCertificates(text As String) As X509Certificate2Collection
        Dim result As New X509Certificate2Collection()
        Const beginMarker As String = "-----BEGIN CERTIFICATE-----"
        Const endMarker As String = "-----END CERTIFICATE-----"
        Dim searchStart As Integer = 0
        While searchStart < text.Length
            Dim begin As Integer = text.IndexOf(beginMarker, searchStart, StringComparison.Ordinal)
            If begin < 0 Then
                Exit While
            End If

            begin += beginMarker.Length
            Dim blockEnd As Integer = text.IndexOf(endMarker, begin, StringComparison.Ordinal)
            If blockEnd < 0 Then
                Throw New InvalidOperationException("The PEM certificate block is missing its end marker.")
            End If

            Dim base64 As String = text.Substring(begin, blockEnd - begin)
            base64 = base64.Replace(vbCr, String.Empty).Replace(vbLf, String.Empty).Trim()
            result.Add(New X509Certificate2(Convert.FromBase64String(base64)))
            searchStart = blockEnd + endMarker.Length
        End While

        Return result
    End Function

    Private Shared Function TryReadText(fileName As String) As String
        Try
            Return File.ReadAllText(fileName)
        Catch
            Return Nothing
        End Try
    End Function

    Private Function GetRoleName(certificate As X509Certificate2) As String
        Try
            Dim roleName As String = SecureModbusRoleExtension.GetRoleName(certificate)
            Return If(String.IsNullOrWhiteSpace(roleName), R("CertificateManager_None_Text", "<none>"), roleName)
        Catch
            Return R("CertificateManager_None_Text", "<none>")
        End Try
    End Function

    Private NotInheritable Class CertificateEntry
        Friend Sub New(storeName As String, filePath As String, certificate As X509Certificate2, loadError As String)
            Me.StoreName = storeName
            Me.FilePath = filePath
            Me.Certificate = certificate
            Me.LoadError = loadError
        End Sub

        Friend ReadOnly Property StoreName As String
        Friend ReadOnly Property FilePath As String
        Friend ReadOnly Property Certificate As X509Certificate2
        Friend ReadOnly Property LoadError As String

        Friend ReadOnly Property IsDateValid As Boolean
            Get
                Return Certificate IsNot Nothing AndAlso DateTime.Now >= Certificate.NotBefore AndAlso DateTime.Now <= Certificate.NotAfter
            End Get
        End Property

        Friend ReadOnly Property StatusText As String
            Get
                If Certificate Is Nothing Then
                    Return "Load error"
                End If
                If DateTime.Now < Certificate.NotBefore Then
                    Return "Not yet valid"
                End If
                If DateTime.Now > Certificate.NotAfter Then
                    Return "Expired"
                End If
                Return "Valid"
            End Get
        End Property

        Friend Shared Function FromError(storeName As String, filePath As String, loadError As String) As CertificateEntry
            Return New CertificateEntry(storeName, filePath, Nothing, loadError)
        End Function
    End Class
End Class
