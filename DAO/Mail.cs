using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using WebGrease.Configuration;
using Pechkin;
using Montres.Models;

namespace Montres.DAO
{
    public class Mail
    {

  
        public void Enviar_Cotizacion_Correo(string cliente, string numero_orden)
        {


            string cadena = "";


            string Date = DateTime.Now.ToString("yyyy-MM-dd");


            List<Partes> list_Partes = (List<Partes>)HttpContext.Current.Session["allList2"];

            double tarifa_total = 0;

            auxiliar aux2 = new auxiliar();

            foreach (var dato in list_Partes)
            {


                tarifa_total = tarifa_total + (dato.Cantidad_Stock * dato.Precio);


                cadena = cadena + "<tr><td>" + dato.Numero_Parte + "</td>" +
                    "<td>" + dato.Descripcion + "</td>" +
                    "<td>" + dato.Ubicacion + "</td>" +
                      "<td>" + dato.Cantidad_Stock + "</td>" +
                      "<td style='font-size: 12px;'>" + aux2.transformar(dato.Precio) + " <br> + IVA</td>";

            }


            try
            {
                


                MailMessage email = new MailMessage();

                email.From = new MailAddress("montresmontacarga@gmail.com");

                email.Subject = "Cotización #"+numero_orden+"";
                email.Body =
                "<html>" +
                "<body style = 'margin: 0; padding: 0;' >" +
                "<table role = 'presentation' border = '0' cellpadding = '0' cellspacing = '0' width = '100%' >       <tr >" +
                "<td style = 'padding: 20px 0 30px 0;' >" +
                "<table align = 'center' border = '0' cellpadding = '0' cellspacing = '0' width = '600' style = 'border-collapse: collapse; border: 1px solid #cccccc;' >" +
                "<tr >" +
                "<td bgcolor = '#ffffff' style = 'padding: 40px 30px 40px 30px;' >" +
                "<table border = '0' cellpadding = '0' cellspacing = '0' width = '100%' style = 'border-collapse: collapse;' >" +
                "<tr >" +
                "<td style = 'color: #153643; font-family: Arial, sans-serif;' >" +
                "<h1 style = 'font-size: 24px; margin: 0;' > Estimado usuario:</h1 >" +
                "</td >" +
                "</tr >" +
                "<tr >" +
                "<td style = 'color: #153643; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px; padding: 20px 0 30px 0;' >" +
                "<p style = 'margin: 0;' > Seguidamente se encuentra la cotización para el cliente "+cliente+" con el número de orden #"+numero_orden+".</p >" +
                "</td >" +
                "</tr >" +
                "<tr >" +
                "<td >  " +
                "</td >" +
                "</tr >" +
                "</table >" +
                "<p style = 'margin: 0; font-size: 18px;' > <strong>Partes:</strong></p >" +
                  "</td >" +
                "</tr >" + 
                "<center>"+
                "<table border style= 'widht:90%;'>" +

              "<thead><tr><th>Número de parte</th><th>Descripción</th><th>Ubicación</th><th>Cantidad</th><th>Precio Unitario </th></tr></thead>" +

              "<tbody>" + cadena + " </tbody> " +

                           "</table>" +
                             "</center>" +

                             "<br><br>   <label style = 'font-size: 18px; margin-left: 30px;' > <strong > Monto total: </strong> </label> " + aux2.transformar(tarifa_total) + " + IVA<br><br>" +

                "<tr >" +
                "<td bgcolor = '#153643' style = 'padding: 30px 30px;' >" +
                "<table border = '0' cellpadding = '0' cellspacing = '0' height= '50px' width = '100%' style = 'border-collapse: collapse;' >" +
                "<tr >" +
                "<td style = 'color: #ffffff; font-family: Arial, sans-serif; font-size: 14px;' >" +
                "<p style = 'margin: 0;' > &reg; MONTRES <br />" +
                "Montres Costa Rica S.A </p >" +
                "</td >" +
                "</tr>" +
                "</table>" +
                "</td >" +
                "</tr >" +
                "</table >" +
                "</td>" +
                "</tr >" +
                "</table >" +
                "</td >" +
                "</tr >" +
                "</table >" +
                "</body >" +
                "</html > ";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;
                email.To.Add( new MailAddress("montresmontacarga@gmail.com"));




                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("montresmontacarga@gmail.com", "montrescr1234");

                string output = null;
                try
                {
                    smtp.Send(email);
                    email.Dispose();
                    output = "Corre electrónico fue enviado satisfactoriamente.";
                }
                catch (Exception ex)
                {
                    output = "Error enviando correo electrónico: " + ex.Message;
                }

                Console.WriteLine(output);


            }
            catch (Exception e)
            {
                string hola = e.Message;

            }

        }

        public bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                FileStream _FileStream = new FileStream(_FileName, FileMode.Create, FileAccess.Write);
                // Writes a block of bytes to this stream using data from  a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                // Close file stream
                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process while trying to save : {0}", _Exception.ToString());
            }

            return false;
        }

    }
}