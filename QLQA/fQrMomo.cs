using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;
using ZXing;
using System.Collections;

namespace QLQA
{
    public partial class fQrMomo : Form
    {

        public double amt;
        public int MainID = 0;


        public fQrMomo()
        {
            InitializeComponent();

            double amt = 0;
            double.TryParse(txt_sotien.Text, out amt);
        }

        private void fQrMomo_Load(object sender, EventArgs e)
        {
            txt_sotien.Text = amt.ToString();
        }


        private void btn_pay_Click(object sender, EventArgs e)
        {
            if (amt > 0)
            {
                var qrcode_text = $"2|99|{txt_phone.Text.Trim()}|{txt_name.Text.Trim()}|{txt_email.Text.Trim()}|0|0|{txt_sotien.Text.Trim()}";
                BarcodeWriter barcodeWriter = new BarcodeWriter();
                EncodingOptions encodingOptions = new EncodingOptions() { Width = 250, Height = 250, Margin = 0, PureBarcode = false };
                encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
                barcodeWriter.Renderer = new BitmapRenderer();
                barcodeWriter.Options = encodingOptions;
                barcodeWriter.Format = BarcodeFormat.QR_CODE;
                Bitmap bitmap = barcodeWriter.Write(qrcode_text);
                Bitmap logo = resizeImage(Properties.Resources.logo_momo, 64, 64) as Bitmap;
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));
                pic_qrcode.Image = bitmap;
            }
            else
            {
                guna2MessageDialog1.Show("Vui lòng chọn đơn hàng cần thanh toán");
            }

        }

        public Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string query = @"Update tblMain set total = @total,
                             status = N'Đã thanh toán' where MainID = @id";

            Hashtable ht = new Hashtable();
            ht.Add("@id", MainID);
            ht.Add("@total", txt_sotien.Text);
 

            if (MainClass.SQL(query, ht) > 0)
            {
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Thanh toán thành công");
                this.Close();
            }
        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
