using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PLCcomMB_Slave_Example_CSharp
{
    /// <summary>
    /// object stores and uses the current values ​​of the bitbar checkboxes
    /// </summary>
    class customCheckBoxes
    {
        #region private member
        private List<CheckBox> mCheckBoxes = new List<CheckBox>();
        #endregion

        #region propertys
        internal CheckBox[] CheckBoxes
        {
            get { return mCheckBoxes.ToArray(); }
        }
        #endregion

        #region global member
        internal void addCheckBox(CheckBox value)
        {
            mCheckBoxes.Add(value);
        }

        /// <summary>
        /// enabled or disabled check state
        /// </summary>
        /// <param name="index">index from desired checkbox</param>
        /// <param name="value">true or false</param>
        /// <returns>true, if the operation successfully, otherwise false</returns>
        internal bool setChecked(int index, bool value)
        {
            try
            {
                if (mCheckBoxes.Count < index - 1) return false;
                mCheckBoxes[index].Checked = value;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// enabled or disabled checkbox
        /// </summary>
        /// <param name="index">index from desired checkbox</param>
        /// <param name="value">true or false</param>
        /// <returns>true, if the operation successfully, otherwise false</returns>
        internal bool setEnabled(int index, bool value)
        {
            try
            {
                if (mCheckBoxes.Count < index - 1) return false;
                mCheckBoxes[index].Enabled = value;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// enabled all ckecboxes of bitbar
        /// </summary>
        /// <param name="Enable16BitBoxes">enable bitbar 0-15</param>
        /// <param name="Enable32BitBoxes">enable bitbar 16-31</param>
        /// <returns>true, if the operation successfully, otherwise false</returns>
        internal bool EnableBitBarComplete(bool Enable16BitBoxes, bool Enable32BitBoxes)
        {
            try
            {
                for (int i = 0; i < mCheckBoxes.Count; i++)
                {
                    if (i < 16)
                    {
                        mCheckBoxes[i].Enabled = Enable16BitBoxes;
                    }
                    else
                    {
                        mCheckBoxes[i].Enabled = Enable32BitBoxes;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// set complete bitbar to true or false
        /// </summary>
        /// <param name="value">true or false</param>
        /// <returns>true, if the operation successfully, otherwise false</returns>
        internal bool SetBitBarComplete(bool value)
        {
            try
            {
                foreach (CheckBox c in mCheckBoxes)
                {
                    c.Checked = value;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// set bitbar depending on the value
        /// </summary>
        /// <param name="value">a Int32 value</param>
        internal void SetCheckBoxesfromValue(uint value)
        {
            byte[] b = System.BitConverter.GetBytes(value);
            BitArray BitAr = new BitArray(b);
            for (int i = 0; i < BitAr.Length; i++)
            {
                mCheckBoxes[i].Checked = BitAr[i];
            }
        }

        /// <summary>
        /// set bitbar depending on the value
        /// </summary>
        /// <param name="value">a Int16 value</param>
        internal void SetCheckBoxesfromValue(ushort value)
        {
            byte[] b = System.BitConverter.GetBytes(value);
            BitArray BitAr = new BitArray(b);
            for (int i = 0; i < BitAr.Length; i++)
            {
                mCheckBoxes[i].Checked = BitAr[i];
            }
        }

        /// <summary>
        /// get value depending on the current bitbar
        /// </summary>
        /// <returns>a Int32 value</returns>
        internal uint getValue()
        {
            uint Value = 0;
            for (int i = 0; i < mCheckBoxes.Count; i++)
            {
                if (mCheckBoxes[i].Checked)
                    Value += (uint)(1 << i);
            }
            return Value;
        }

        #endregion
    }
}
