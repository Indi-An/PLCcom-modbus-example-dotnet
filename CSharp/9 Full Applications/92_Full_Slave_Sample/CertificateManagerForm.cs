using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using PLCcomModbus.Core.Security;

namespace PLCcomMB_Slave_Example_CSharp
{
    internal sealed class CertificateManagerForm : Form
    {
        private readonly SecureModbusPkiStore pkiStore;
        private readonly List<CertificateEntry> entries = new List<CertificateEntry>();
        private ListView listViewCertificates;
        private RichTextBox textBoxDetails;
        private Button buttonTrust;
        private Button buttonTrustIssuer;
        private Button buttonReject;
        private Button buttonDelete;
        private Button buttonRefresh;
        private Button buttonOpenPki;
        private Button buttonEnsureOwn;
        private Button buttonClose;
        private Label labelPkiPath;
        private Label labelStatus;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem menuTrust;
        private ToolStripMenuItem menuTrustIssuer;
        private ToolStripMenuItem menuReject;
        private ToolStripMenuItem menuDelete;
        private ToolStripMenuItem menuOpenFolder;
        private ToolStripMenuItem menuCopyThumbprint;
        private ToolStripMenuItem menuRefresh;
        private ImageList storeImages;
        private ToolTip buttonToolTip;
        private readonly System.Resources.ResourceManager resources;

        internal CertificateManagerForm()
        {
            pkiStore = SecureTcpExampleOptions.CreatePkiStore();
            resources = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", GetType().Assembly);
            InitializeComponent();
            LoadEntries();
        }

        private void InitializeComponent()
        {
            Text = R("CertificateManagerForm_Text", "SecureTCP Certificate Manager");
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(980, 620);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = SystemIcons.Shield;
            MaximizeBox = false;
            MinimizeBox = false;
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            Panel headerPanel = new Panel();
            headerPanel.BackColor = Color.FromArgb(245, 248, 252);
            headerPanel.Location = new Point(0, 0);
            headerPanel.Size = new Size(ClientSize.Width, 84);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(18, 18);
            pictureBox.Size = new Size(40, 40);
            pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox.Image = SystemIcons.Shield.ToBitmap();

            Label labelTitle = new Label();
            labelTitle.AutoSize = false;
            labelTitle.Font = new Font(Font, FontStyle.Bold);
            labelTitle.Location = new Point(70, 14);
            labelTitle.Size = new Size(880, 22);
            labelTitle.Text = R("CertificateManager_Title_Text", "SecureTCP PKI store");

            labelPkiPath = new Label();
            labelPkiPath.AutoEllipsis = true;
            labelPkiPath.Location = new Point(70, 36);
            labelPkiPath.Size = new Size(880, 18);
            labelPkiPath.Text = pkiStore.BasePath;

            labelStatus = new Label();
            labelStatus.AutoEllipsis = true;
            labelStatus.Location = new Point(70, 58);
            labelStatus.Size = new Size(880, 18);
            labelStatus.Text = R("CertificateManager_Loading_Text", "Loading certificates...");

            headerPanel.Controls.Add(pictureBox);
            headerPanel.Controls.Add(labelTitle);
            headerPanel.Controls.Add(labelPkiPath);
            headerPanel.Controls.Add(labelStatus);

            storeImages = new ImageList();
            storeImages.ColorDepth = ColorDepth.Depth32Bit;
            storeImages.ImageSize = new Size(16, 16);
            storeImages.Images.Add("Own", SystemIcons.Application.ToBitmap());
            storeImages.Images.Add("Trusted", SystemIcons.Shield.ToBitmap());
            storeImages.Images.Add("Issuers", SystemIcons.Information.ToBitmap());
            storeImages.Images.Add("Rejected", SystemIcons.Warning.ToBitmap());
            storeImages.Images.Add("Error", SystemIcons.Error.ToBitmap());

            listViewCertificates = new ListView();
            listViewCertificates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewCertificates.FullRowSelect = true;
            listViewCertificates.GridLines = false;
            listViewCertificates.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewCertificates.HideSelection = false;
            listViewCertificates.MultiSelect = false;
            listViewCertificates.View = View.Details;
            listViewCertificates.SmallImageList = storeImages;
            listViewCertificates.Location = new Point(16, 98);
            listViewCertificates.Size = new Size(948, 300);
            listViewCertificates.Columns.Add(R("CertificateManager_ColumnStore_Text", "Store"));
            listViewCertificates.Columns.Add(R("CertificateManager_ColumnStatus_Text", "Status"));
            listViewCertificates.Columns.Add(R("CertificateManager_ColumnFile_Text", "File"));
            listViewCertificates.Columns.Add(R("CertificateManager_ColumnSubject_Text", "Subject"));
            listViewCertificates.Columns.Add(R("CertificateManager_ColumnIssuer_Text", "Issuer"));
            listViewCertificates.Columns.Add(R("CertificateManager_ColumnValidTo_Text", "Valid to"));
            listViewCertificates.Columns.Add(R("CertificateManager_ColumnRole_Text", "Role"));
            listViewCertificates.SelectedIndexChanged += listViewCertificates_SelectedIndexChanged;
            listViewCertificates.MouseDown += listViewCertificates_MouseDown;
            listViewCertificates.MouseDoubleClick += listViewCertificates_MouseDoubleClick;
            FitCertificateColumns();

            contextMenu = new ContextMenuStrip();
            menuTrust = new ToolStripMenuItem(R("CertificateManager_MenuTrust_Text", "Trust certificate"), null, menuTrust_Click);
            menuTrustIssuer = new ToolStripMenuItem(R("CertificateManager_MenuTrustIssuer_Text", "Trust as issuer"), null, menuTrustIssuer_Click);
            menuReject = new ToolStripMenuItem(R("CertificateManager_MenuReject_Text", "Reject certificate"), null, menuReject_Click);
            menuDelete = new ToolStripMenuItem(R("CertificateManager_MenuDelete_Text", "Delete file"), null, menuDelete_Click);
            menuOpenFolder = new ToolStripMenuItem(R("CertificateManager_MenuOpenFolder_Text", "Open containing folder"), null, menuOpenFolder_Click);
            menuCopyThumbprint = new ToolStripMenuItem(R("CertificateManager_MenuCopyThumbprint_Text", "Copy thumbprint"), null, menuCopyThumbprint_Click);
            menuRefresh = new ToolStripMenuItem(R("CertificateManager_MenuRefresh_Text", "Refresh"), null, menuRefresh_Click);
            contextMenu.Items.AddRange(new ToolStripItem[]
            {
                menuTrust,
                menuTrustIssuer,
                menuReject,
                new ToolStripSeparator(),
                menuCopyThumbprint,
                menuOpenFolder,
                new ToolStripSeparator(),
                menuDelete,
                menuRefresh
            });
            contextMenu.Opening += contextMenu_Opening;
            listViewCertificates.ContextMenuStrip = contextMenu;

            GroupBox detailsGroup = new GroupBox();
            detailsGroup.Location = new Point(16, 414);
            detailsGroup.Size = new Size(948, 100);
            detailsGroup.Text = R("CertificateManager_DetailsGroup_Text", "Certificate details");

            textBoxDetails = new RichTextBox();
            textBoxDetails.BorderStyle = BorderStyle.None;
            textBoxDetails.Location = new Point(12, 22);
            textBoxDetails.Multiline = true;
            textBoxDetails.ReadOnly = true;
            textBoxDetails.ScrollBars = RichTextBoxScrollBars.Vertical;
            textBoxDetails.Size = new Size(924, 64);
            textBoxDetails.BackColor = SystemColors.Window;
            detailsGroup.Controls.Add(textBoxDetails);

            Panel footerPanel = new Panel();
            footerPanel.BackColor = Color.FromArgb(248, 248, 248);
            footerPanel.Location = new Point(0, 532);
            footerPanel.Size = new Size(ClientSize.Width, 88);
            Panel separator = new Panel();
            separator.BackColor = Color.Gainsboro;
            separator.Location = new Point(0, 0);
            separator.Size = new Size(ClientSize.Width, 1);
            footerPanel.Controls.Add(separator);

            buttonToolTip = new ToolTip();
            buttonEnsureOwn = CreateFooterButton(R("CertificateManager_ButtonOwn_Text", "Own"), 16, buttonEnsureOwn_Click, CreateOwnCertificateImage(), R("CertificateManager_ButtonOwn_ToolTip", "Create or load the own SecureTCP certificate."));
            buttonOpenPki = CreateFooterButton(R("CertificateManager_ButtonOpenPki_Text", "PKI"), 94, buttonOpenPki_Click, CreateOpenPkiImage(), R("CertificateManager_ButtonOpenPki_ToolTip", "Open the SecureTCP PKI folder."));
            buttonRefresh = CreateFooterButton(R("CertificateManager_ButtonRefresh_Text", "Refresh"), 172, buttonRefresh_Click, CreateRefreshImage(), R("CertificateManager_ButtonRefresh_ToolTip", "Refresh the certificate list."));
            buttonTrust = CreateFooterButton(R("CertificateManager_ButtonTrust_Text", "Trust"), 440, buttonTrust_Click, CreateTrustImage(), R("CertificateManager_ButtonTrust_ToolTip", "Move the selected rejected certificate to trusted."));
            buttonTrustIssuer = CreateFooterButton(R("CertificateManager_ButtonIssuer_Text", "Issuer"), 518, buttonTrustIssuer_Click, CreateIssuerImage(), R("CertificateManager_ButtonIssuer_ToolTip", "Move the selected certificate to issuers."));
            buttonReject = CreateFooterButton(R("CertificateManager_ButtonReject_Text", "Reject"), 596, buttonReject_Click, CreateRejectImage(), R("CertificateManager_ButtonReject_ToolTip", "Move the selected certificate to rejected."));
            buttonDelete = CreateFooterButton(R("CertificateManager_ButtonDelete_Text", "Delete"), 674, buttonDelete_Click, CreateDeleteImage(), R("CertificateManager_ButtonDelete_ToolTip", "Delete the selected certificate file."));
            buttonClose = CreateFooterButton(R("CertificateManager_ButtonClose_Text", "close\r\nwindow"), 896, buttonClose_Click, GetCloseButtonImage(), R("CertificateManager_ButtonClose_ToolTip", "Close this window."));
            buttonClose.DialogResult = DialogResult.Cancel;
            CancelButton = buttonClose;

            footerPanel.Controls.Add(buttonEnsureOwn);
            footerPanel.Controls.Add(buttonOpenPki);
            footerPanel.Controls.Add(buttonRefresh);
            footerPanel.Controls.Add(buttonTrust);
            footerPanel.Controls.Add(buttonTrustIssuer);
            footerPanel.Controls.Add(buttonReject);
            footerPanel.Controls.Add(buttonDelete);
            footerPanel.Controls.Add(buttonClose);

            Controls.Add(headerPanel);
            Controls.Add(listViewCertificates);
            Controls.Add(detailsGroup);
            Controls.Add(footerPanel);
        }

        private string R(string name, string fallback)
        {
            string value = resources.GetString(name);
            return string.IsNullOrEmpty(value) ? fallback : value;
        }

        private string GetStoreText(string storeName)
        {
            switch (storeName)
            {
                case "Own":
                    return R("CertificateManager_StoreOwn_Text", "Own");
                case "Trusted":
                    return R("CertificateManager_StoreTrusted_Text", "Trusted");
                case "Issuers":
                    return R("CertificateManager_StoreIssuers_Text", "Issuers");
                case "Rejected":
                    return R("CertificateManager_StoreRejected_Text", "Rejected");
                default:
                    return storeName;
            }
        }

        private string GetStatusText(CertificateEntry entry)
        {
            if (entry.Certificate == null)
                return R("CertificateManager_StatusLoadError_Text", "Load error");
            if (DateTime.Now < entry.Certificate.NotBefore)
                return R("CertificateManager_StatusNotYetValid_Text", "Not yet valid");
            if (DateTime.Now > entry.Certificate.NotAfter)
                return R("CertificateManager_StatusExpired_Text", "Expired");
            return R("CertificateManager_StatusValid_Text", "Valid");
        }

        private Button CreateFooterButton(string text, int left, EventHandler clickHandler, Image image, string toolTipText)
        {
            Button button = new Button();
            button.AutoSize = false;
            button.Font = Font;
            button.Image = image;
            button.ImageAlign = ContentAlignment.TopCenter;
            button.Location = new Point(left, 10);
            button.MinimumSize = new Size(68, 68);
            button.MaximumSize = new Size(68, 68);
            button.Padding = new Padding(2, 4, 2, 3);
            button.Size = new Size(68, 68);
            button.Text = text;
            button.TextAlign = ContentAlignment.BottomCenter;
            button.TextImageRelation = TextImageRelation.ImageAboveText;
            button.UseVisualStyleBackColor = true;
            button.Click += clickHandler;
            buttonToolTip.SetToolTip(button, toolTipText);
            return button;
        }

        private static Image CreateOwnCertificateImage()
        {
            Bitmap bitmap = CreateIconBitmap();
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                PrepareIconGraphics(graphics);
                using (SolidBrush paperBrush = new SolidBrush(Color.FromArgb(255, 248, 220)))
                using (Pen borderPen = new Pen(Color.FromArgb(148, 126, 70), 1.4f))
                using (SolidBrush sealBrush = new SolidBrush(Color.FromArgb(64, 132, 206)))
                using (Pen keyPen = new Pen(Color.FromArgb(88, 88, 88), 2.0f))
                {
                    graphics.FillRectangle(paperBrush, 6, 3, 17, 23);
                    graphics.DrawRectangle(borderPen, 6, 3, 17, 23);
                    graphics.FillEllipse(sealBrush, 17, 17, 8, 8);
                    graphics.DrawEllipse(keyPen, 7, 20, 6, 6);
                    graphics.DrawLine(keyPen, 13, 23, 25, 23);
                    graphics.DrawLine(keyPen, 21, 23, 21, 27);
                }
            }

            return bitmap;
        }

        private static Image CreateOpenPkiImage()
        {
            Bitmap bitmap = CreateIconBitmap();
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                PrepareIconGraphics(graphics);
                using (SolidBrush tabBrush = new SolidBrush(Color.FromArgb(245, 196, 72)))
                using (SolidBrush folderBrush = new SolidBrush(Color.FromArgb(255, 214, 93)))
                using (Pen borderPen = new Pen(Color.FromArgb(163, 125, 42), 1.3f))
                {
                    graphics.FillRectangle(tabBrush, 4, 8, 10, 5);
                    graphics.FillRectangle(folderBrush, 4, 12, 24, 14);
                    graphics.DrawRectangle(borderPen, 4, 8, 10, 5);
                    graphics.DrawRectangle(borderPen, 4, 12, 24, 14);
                }
            }

            return bitmap;
        }

        private static Image CreateRefreshImage()
        {
            Bitmap bitmap = CreateIconBitmap();
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                PrepareIconGraphics(graphics);
                using (Pen arrowPen = new Pen(Color.FromArgb(44, 112, 176), 2.4f))
                using (SolidBrush arrowBrush = new SolidBrush(Color.FromArgb(44, 112, 176)))
                {
                    arrowPen.StartCap = LineCap.Round;
                    arrowPen.EndCap = LineCap.Round;
                    graphics.DrawArc(arrowPen, 6, 6, 20, 20, 35, 260);
                    graphics.FillPolygon(arrowBrush, new Point[] { new Point(24, 7), new Point(29, 8), new Point(26, 13) });
                }
            }

            return bitmap;
        }

        private static Image CreateTrustImage()
        {
            Bitmap bitmap = CreateIconBitmap();
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                PrepareIconGraphics(graphics);
                using (SolidBrush shieldBrush = new SolidBrush(Color.FromArgb(47, 150, 82)))
                using (Pen checkPen = new Pen(Color.White, 3.0f))
                {
                    graphics.FillPolygon(shieldBrush, CreateShieldPoints());
                    checkPen.StartCap = LineCap.Round;
                    checkPen.EndCap = LineCap.Round;
                    graphics.DrawLines(checkPen, new Point[] { new Point(9, 17), new Point(14, 22), new Point(24, 11) });
                }
            }

            return bitmap;
        }

        private static Image CreateIssuerImage()
        {
            Bitmap bitmap = CreateIconBitmap();
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                PrepareIconGraphics(graphics);
                using (SolidBrush paperBrush = new SolidBrush(Color.White))
                using (Pen borderPen = new Pen(Color.FromArgb(78, 126, 176), 1.4f))
                using (SolidBrush sealBrush = new SolidBrush(Color.FromArgb(64, 132, 206)))
                using (Pen linePen = new Pen(Color.FromArgb(145, 160, 178), 1.3f))
                {
                    graphics.FillRectangle(paperBrush, 7, 4, 18, 23);
                    graphics.DrawRectangle(borderPen, 7, 4, 18, 23);
                    graphics.DrawLine(linePen, 11, 10, 21, 10);
                    graphics.DrawLine(linePen, 11, 14, 21, 14);
                    graphics.FillEllipse(sealBrush, 12, 17, 8, 8);
                }
            }

            return bitmap;
        }

        private static Image CreateRejectImage()
        {
            Bitmap bitmap = CreateIconBitmap();
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                PrepareIconGraphics(graphics);
                using (SolidBrush rejectBrush = new SolidBrush(Color.FromArgb(198, 57, 57)))
                using (Pen linePen = new Pen(Color.White, 3.4f))
                {
                    graphics.FillEllipse(rejectBrush, 5, 5, 22, 22);
                    linePen.StartCap = LineCap.Round;
                    linePen.EndCap = LineCap.Round;
                    graphics.DrawLine(linePen, 10, 16, 22, 16);
                }
            }

            return bitmap;
        }

        private static Image CreateDeleteImage()
        {
            Bitmap bitmap = CreateIconBitmap();
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                PrepareIconGraphics(graphics);
                using (SolidBrush binBrush = new SolidBrush(Color.FromArgb(118, 126, 135)))
                using (Pen borderPen = new Pen(Color.FromArgb(80, 88, 96), 1.4f))
                using (Pen xPen = new Pen(Color.FromArgb(205, 58, 58), 2.2f))
                {
                    graphics.FillRectangle(binBrush, 10, 12, 13, 15);
                    graphics.DrawRectangle(borderPen, 10, 12, 13, 15);
                    graphics.DrawLine(borderPen, 8, 10, 25, 10);
                    graphics.DrawLine(borderPen, 13, 7, 20, 7);
                    graphics.DrawLine(xPen, 13, 16, 20, 23);
                    graphics.DrawLine(xPen, 20, 16, 13, 23);
                }
            }

            return bitmap;
        }

        private static Bitmap CreateIconBitmap()
        {
            Bitmap bitmap = new Bitmap(32, 32);
            bitmap.MakeTransparent();
            return bitmap;
        }

        private static void PrepareIconGraphics(Graphics graphics)
        {
            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
        }

        private static Point[] CreateShieldPoints()
        {
            return new Point[]
            {
                new Point(16, 3),
                new Point(27, 8),
                new Point(25, 20),
                new Point(16, 29),
                new Point(7, 20),
                new Point(5, 8)
            };
        }

        private void FitCertificateColumns()
        {
            int availableWidth = listViewCertificates.ClientSize.Width - 4;
            if (entries.Count > 8)
                availableWidth -= SystemInformation.VerticalScrollBarWidth;

            int[] fixedWidths = new int[] { 78, 80, 150, 245, 205, 80 };
            int usedWidth = 0;
            for (int index = 0; index < fixedWidths.Length; index++)
            {
                listViewCertificates.Columns[index].Width = fixedWidths[index];
                usedWidth += fixedWidths[index];
            }

            listViewCertificates.Columns[6].Width = Math.Max(70, availableWidth - usedWidth);
        }

        private void LoadEntries()
        {
            pkiStore.EnsureDirectories();
            entries.Clear();
            AddEntries("Own", pkiStore.OwnCertificatesPath);
            AddEntries("Trusted", pkiStore.TrustedCertificatesPath);
            AddEntries("Issuers", pkiStore.IssuerCertificatesPath);
            AddEntries("Rejected", pkiStore.RejectedCertificatesPath);

            listViewCertificates.BeginUpdate();
            try
            {
                listViewCertificates.Items.Clear();
                foreach (CertificateEntry entry in entries)
                {
                    ListViewItem item = new ListViewItem(GetStoreText(entry.StoreName));
                    item.ImageKey = entry.Certificate == null ? "Error" : entry.StoreName;
                    item.SubItems.Add(GetStatusText(entry));
                    item.SubItems.Add(Path.GetFileName(entry.FilePath));
                    item.SubItems.Add(entry.Certificate == null ? R("CertificateManager_NotLoaded_Text", "<not loaded>") : entry.Certificate.Subject);
                    item.SubItems.Add(entry.Certificate == null ? string.Empty : entry.Certificate.Issuer);
                    item.SubItems.Add(entry.Certificate == null ? string.Empty : entry.Certificate.NotAfter.ToString("yyyy-MM-dd"));
                    item.SubItems.Add(entry.Certificate == null ? string.Empty : GetRoleName(entry.Certificate));
                    item.Tag = entry;
                    ApplyItemStyle(item, entry);
                    listViewCertificates.Items.Add(item);
                }
            }
            finally
            {
                listViewCertificates.EndUpdate();
            }

            FitCertificateColumns();
            UpdateStoreStatus();
            UpdateSelectionState();
        }

        private static void ApplyItemStyle(ListViewItem item, CertificateEntry entry)
        {
            if (entry.Certificate == null)
            {
                item.ForeColor = Color.Firebrick;
                item.BackColor = Color.MistyRose;
            }
            else if (!entry.IsDateValid)
            {
                item.ForeColor = Color.DarkOrange;
                item.BackColor = Color.FromArgb(255, 248, 220);
            }
            else if (entry.StoreName == "Rejected")
            {
                item.BackColor = Color.FromArgb(255, 238, 238);
            }
            else if (entry.StoreName == "Trusted" || entry.StoreName == "Issuers")
            {
                item.BackColor = Color.FromArgb(240, 250, 240);
            }
        }

        private void AddEntries(string storeName, string directory)
        {
            if (!Directory.Exists(directory))
                return;

            foreach (string filePath in Directory.GetFiles(directory))
            {
                if (!HasCertificateExtension(filePath))
                    continue;

                try
                {
                    X509Certificate2Collection certificates = LoadCertificatesFromFile(filePath);
                    if (certificates.Count == 0)
                        entries.Add(CertificateEntry.FromError(storeName, filePath, R("CertificateManager_ErrorNoCertificate_Text", "The file does not contain a certificate.")));

                    foreach (X509Certificate2 certificate in certificates)
                        entries.Add(new CertificateEntry(storeName, filePath, certificate, null));
                }
                catch (Exception ex)
                {
                    entries.Add(CertificateEntry.FromError(storeName, filePath, ex.Message));
                }
            }
        }

        private void UpdateStoreStatus()
        {
            int own = CountEntries("Own");
            int trusted = CountEntries("Trusted");
            int issuers = CountEntries("Issuers");
            int rejected = CountEntries("Rejected");
            labelStatus.Text = string.Format(R("CertificateManager_StatusCounts_Text", "Own: {0}    Trusted: {1}    Issuers: {2}    Rejected: {3}"), own, trusted, issuers, rejected);
            labelStatus.ForeColor = rejected > 0 ? Color.Firebrick : Color.DarkGreen;
        }

        private int CountEntries(string storeName)
        {
            int count = 0;
            foreach (CertificateEntry entry in entries)
            {
                if (entry.StoreName == storeName)
                    count++;
            }

            return count;
        }

        private void UpdateSelectionState()
        {
            CertificateEntry entry = SelectedEntry;
            bool hasCertificate = entry != null && entry.Certificate != null;
            bool canTrust = hasCertificate && entry.StoreName == "Rejected";
            bool canReject = hasCertificate && entry.StoreName != "Rejected" && entry.StoreName != "Own";
            bool canTrustIssuer = hasCertificate && entry.StoreName != "Issuers" && entry.StoreName != "Own";
            buttonTrust.Enabled = canTrust;
            buttonTrustIssuer.Enabled = canTrustIssuer;
            buttonReject.Enabled = canReject;
            buttonDelete.Enabled = entry != null;

            if (entry == null)
            {
                textBoxDetails.Text = R("CertificateManager_SelectCertificate_Text", "Select a certificate to see its details. Use the context menu to trust, reject, delete, or inspect certificate files.");
                return;
            }

            textBoxDetails.Text = BuildDetails(entry);
        }

        private CertificateEntry SelectedEntry
        {
            get
            {
                if (listViewCertificates.SelectedItems.Count == 0)
                    return null;

                return listViewCertificates.SelectedItems[0].Tag as CertificateEntry;
            }
        }

        private string BuildDetails(CertificateEntry entry)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(R("CertificateManager_DetailStore_Text", "Store:") + " " + GetStoreText(entry.StoreName));
            builder.AppendLine(R("CertificateManager_DetailStatus_Text", "Status:") + " " + GetStatusText(entry));
            builder.AppendLine(R("CertificateManager_DetailFile_Text", "File:") + " " + entry.FilePath);
            if (entry.Certificate == null)
            {
                builder.AppendLine(R("CertificateManager_DetailLoadError_Text", "Load error:") + " " + entry.LoadError);
                return builder.ToString();
            }

            builder.AppendLine(R("CertificateManager_DetailSubject_Text", "Subject:") + " " + entry.Certificate.Subject);
            builder.AppendLine(R("CertificateManager_DetailIssuer_Text", "Issuer:") + " " + entry.Certificate.Issuer);
            builder.AppendLine(R("CertificateManager_DetailThumbprint_Text", "Thumbprint:") + " " + entry.Certificate.Thumbprint);
            builder.AppendLine(R("CertificateManager_DetailSerial_Text", "Serial:") + " " + entry.Certificate.SerialNumber);
            builder.AppendLine(R("CertificateManager_DetailValidFrom_Text", "Valid from:") + " " + entry.Certificate.NotBefore.ToString("yyyy-MM-dd HH:mm:ss"));
            builder.AppendLine(R("CertificateManager_DetailValidTo_Text", "Valid to:") + " " + entry.Certificate.NotAfter.ToString("yyyy-MM-dd HH:mm:ss"));
            builder.AppendLine(R("CertificateManager_DetailRole_Text", "Role:") + " " + GetRoleName(entry.Certificate));
            builder.AppendLine(R("CertificateManager_DetailPrivateKey_Text", "Private key:") + " " + (entry.Certificate.HasPrivateKey ? R("CertificateManager_Yes_Text", "yes") : R("CertificateManager_No_Text", "no")));
            return builder.ToString();
        }

        private void listViewCertificates_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectionState();
        }

        private void listViewCertificates_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            ListViewItem item = listViewCertificates.GetItemAt(e.X, e.Y);
            if (item == null)
                return;

            item.Selected = true;
            item.Focused = true;
        }

        private void listViewCertificates_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CertificateEntry entry = SelectedEntry;
            if (entry != null)
                MessageBox.Show(BuildDetails(entry), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            UpdateSelectionState();
            CertificateEntry entry = SelectedEntry;
            bool hasCertificate = entry != null && entry.Certificate != null;
            menuTrust.Enabled = hasCertificate && entry.StoreName == "Rejected";
            menuTrustIssuer.Enabled = hasCertificate && entry.StoreName != "Issuers" && entry.StoreName != "Own";
            menuReject.Enabled = hasCertificate && entry.StoreName != "Rejected" && entry.StoreName != "Own";
            menuDelete.Enabled = entry != null;
            menuCopyThumbprint.Enabled = hasCertificate;
            menuOpenFolder.Enabled = entry != null;
        }

        private void buttonEnsureOwn_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2 certificate = SecureTcpExampleOptions.EnsureOwnCertificate();
                MessageBox.Show(R("CertificateManager_OwnCertificateAvailable_Text", "Own certificate is available:") + Environment.NewLine + certificate.Subject, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEntries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonTrust_Click(object sender, EventArgs e)
        {
            MoveSelectedCertificate(SecureModbusPkiStoreKind.Trusted);
        }

        private void buttonTrustIssuer_Click(object sender, EventArgs e)
        {
            MoveSelectedCertificate(SecureModbusPkiStoreKind.Issuer);
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            MoveSelectedCertificate(SecureModbusPkiStoreKind.Rejected);
        }

        private void menuTrust_Click(object sender, EventArgs e)
        {
            MoveSelectedCertificate(SecureModbusPkiStoreKind.Trusted);
        }

        private void menuTrustIssuer_Click(object sender, EventArgs e)
        {
            MoveSelectedCertificate(SecureModbusPkiStoreKind.Issuer);
        }

        private void menuReject_Click(object sender, EventArgs e)
        {
            MoveSelectedCertificate(SecureModbusPkiStoreKind.Rejected);
        }

        private void MoveSelectedCertificate(SecureModbusPkiStoreKind targetStoreKind)
        {
            CertificateEntry entry = SelectedEntry;
            if (entry == null || entry.Certificate == null)
                return;

            try
            {
                string targetDirectory;
                string targetStoreName;
                string targetPath;
                switch (targetStoreKind)
                {
                    case SecureModbusPkiStoreKind.Trusted:
                        targetDirectory = pkiStore.TrustedCertificatesPath;
                        targetStoreName = "Trusted";
                        targetPath = pkiStore.StoreTrustedCertificate(entry.Certificate);
                        break;
                    case SecureModbusPkiStoreKind.Issuer:
                        targetDirectory = pkiStore.IssuerCertificatesPath;
                        targetStoreName = "Issuers";
                        targetPath = pkiStore.StoreIssuerCertificate(entry.Certificate);
                        break;
                    case SecureModbusPkiStoreKind.Rejected:
                        targetDirectory = pkiStore.RejectedCertificatesPath;
                        targetStoreName = "Rejected";
                        targetPath = pkiStore.StoreRejectedCertificate(entry.Certificate);
                        break;
                    default:
                        return;
                }

                DeleteSourceFileIfItIsInPki(entry.FilePath, targetDirectory);
                MessageBox.Show(string.Format(R("CertificateManager_CertificateMoved_Text", "Certificate moved to {0}."), GetStoreText(targetStoreName)) + Environment.NewLine + targetPath, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEntries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedCertificate();
        }

        private void menuDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedCertificate();
        }

        private void DeleteSelectedCertificate()
        {
            CertificateEntry entry = SelectedEntry;
            if (entry == null)
                return;

            if (MessageBox.Show(R("CertificateManager_DeleteQuestion_Text", "Delete certificate file?") + Environment.NewLine + entry.FilePath, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                DeleteSourceFileIfItIsInPki(entry.FilePath, null);
                LoadEntries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadEntries();
        }

        private void menuRefresh_Click(object sender, EventArgs e)
        {
            LoadEntries();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static Image GetCloseButtonImage()
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Main));
                return resources.GetObject("btnClose.Image") as Image;
            }
            catch
            {
                return SystemIcons.Error.ToBitmap();
            }
        }

        private void buttonOpenPki_Click(object sender, EventArgs e)
        {
            OpenFolder(pkiStore.BasePath);
        }

        private void menuOpenFolder_Click(object sender, EventArgs e)
        {
            CertificateEntry entry = SelectedEntry;
            if (entry == null)
                return;

            OpenFolder(Path.GetDirectoryName(entry.FilePath));
        }

        private void menuCopyThumbprint_Click(object sender, EventArgs e)
        {
            CertificateEntry entry = SelectedEntry;
            if (entry == null || entry.Certificate == null || string.IsNullOrWhiteSpace(entry.Certificate.Thumbprint))
                return;

            Clipboard.SetText(entry.Certificate.Thumbprint, TextDataFormat.Text);
        }

        private void OpenFolder(string folder)
        {
            try
            {
                pkiStore.EnsureDirectories();
                Process.Start(new ProcessStartInfo(folder) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DeleteSourceFileIfItIsInPki(string filePath, string targetDirectory)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                return;

            string fullPath = Path.GetFullPath(filePath);
            string pkiBasePath = Path.GetFullPath(pkiStore.BasePath).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            if (!fullPath.StartsWith(pkiBasePath, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException(R("CertificateManager_ErrorOutsidePki_Text", "Refusing to delete a file outside the PKI store:") + " " + fullPath);

            if (!string.IsNullOrWhiteSpace(targetDirectory))
            {
                string sourceDirectory = Path.GetFullPath(Path.GetDirectoryName(fullPath)).TrimEnd(Path.DirectorySeparatorChar);
                string normalizedTargetDirectory = Path.GetFullPath(targetDirectory).TrimEnd(Path.DirectorySeparatorChar);
                if (string.Equals(sourceDirectory, normalizedTargetDirectory, StringComparison.OrdinalIgnoreCase))
                    return;
            }

            File.Delete(fullPath);
        }

        private static bool HasCertificateExtension(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            return string.Equals(extension, ".der", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".cer", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".cert", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".crt", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".pem", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".pfx", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".p12", StringComparison.OrdinalIgnoreCase);
        }

        private static X509Certificate2Collection LoadCertificatesFromFile(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            if (string.Equals(extension, ".pfx", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(extension, ".p12", StringComparison.OrdinalIgnoreCase))
            {
                X509Certificate2Collection collection = new X509Certificate2Collection();
                collection.Import(File.ReadAllBytes(fileName), string.Empty, X509KeyStorageFlags.Exportable);
                return collection;
            }

            string text = TryReadText(fileName);
            if (text != null && text.IndexOf("-----BEGIN CERTIFICATE-----", StringComparison.Ordinal) >= 0)
                return LoadPemCertificates(text);

            X509Certificate2Collection result = new X509Certificate2Collection();
            result.Add(new X509Certificate2(fileName));
            return result;
        }

        private static X509Certificate2Collection LoadPemCertificates(string text)
        {
            X509Certificate2Collection result = new X509Certificate2Collection();
            const string beginMarker = "-----BEGIN CERTIFICATE-----";
            const string endMarker = "-----END CERTIFICATE-----";
            int searchStart = 0;
            while (searchStart < text.Length)
            {
                int begin = text.IndexOf(beginMarker, searchStart, StringComparison.Ordinal);
                if (begin < 0)
                    break;

                begin += beginMarker.Length;
                int end = text.IndexOf(endMarker, begin, StringComparison.Ordinal);
                if (end < 0)
                    throw new InvalidOperationException("The PEM certificate block is missing its end marker.");

                string base64 = text.Substring(begin, end - begin);
                base64 = base64.Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
                result.Add(new X509Certificate2(Convert.FromBase64String(base64)));
                searchStart = end + endMarker.Length;
            }

            return result;
        }

        private static string TryReadText(string fileName)
        {
            try
            {
                return File.ReadAllText(fileName);
            }
            catch
            {
                return null;
            }
        }

        private string GetRoleName(X509Certificate2 certificate)
        {
            try
            {
                string roleName = SecureModbusRoleExtension.GetRoleName(certificate);
                return string.IsNullOrWhiteSpace(roleName) ? R("CertificateManager_None_Text", "<none>") : roleName;
            }
            catch
            {
                return R("CertificateManager_None_Text", "<none>");
            }
        }

        private sealed class CertificateEntry
        {
            internal CertificateEntry(string storeName, string filePath, X509Certificate2 certificate, string loadError)
            {
                StoreName = storeName;
                FilePath = filePath;
                Certificate = certificate;
                LoadError = loadError;
            }

            internal string StoreName { get; private set; }
            internal string FilePath { get; private set; }
            internal X509Certificate2 Certificate { get; private set; }
            internal string LoadError { get; private set; }

            internal bool IsDateValid
            {
                get
                {
                    return Certificate != null &&
                           DateTime.Now >= Certificate.NotBefore &&
                           DateTime.Now <= Certificate.NotAfter;
                }
            }

            internal string StatusText
            {
                get
                {
                    if (Certificate == null)
                        return "Load error";
                    if (DateTime.Now < Certificate.NotBefore)
                        return "Not yet valid";
                    if (DateTime.Now > Certificate.NotAfter)
                        return "Expired";
                    return "Valid";
                }
            }

            internal static CertificateEntry FromError(string storeName, string filePath, string loadError)
            {
                return new CertificateEntry(storeName, filePath, null, loadError);
            }
        }
    }
}

