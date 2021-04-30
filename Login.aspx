<%@ Page Language="C#" Async="true" AutoEventWireup="true"   CodeBehind="Login.aspx.cs" Inherits="Montres.Login" %>
<!DOCTYPE html>
<html lang="es">
    <head>
        <title>Inicio de sesión</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="Shortcut Icon" type="image/x-icon" href="assets/icons/montres.ico" />
        <link rel="stylesheet" href="css/loginnew.css"/>
        <meta http-equiv="Expires" content="0" />
        <meta http-equiv="Pragma" content="no-cache" />

            <!--Estilos alertifyjs-->
       <script src="alertifyjs/alertify.min.js"></script>
       <link rel="stylesheet" href="alertifyjs/css/alertify.min.css" />
       <link rel="stylesheet" href="alertifyjs/css/themes/default.min.css" />

        </head>

            
       <script type="text/javascript">

           function Alert_False() {
               alertify.set('notifier', 'position', 'top-right');
               alertify.error('Usuario o contraseña incorrecta');
           };

       </script>



    <body  style="background-image: url('assets/img/fondo.jpg');">


           <figure>
                        <img src="assets/img/logo.png" alt="Montres"  width="200" height="75">
                    </figure>
        
        <div class="container">





 <div id="card">
    <div id="card-content">
      <div id="card-title">
        <h2>LOGIN</h2>
        <div class="underline-title"></div>
      </div>
      <form runat="server" method="post" class="form">

        <label for="user-email" style="padding-top:13px">
            &nbsp;Cédula
          </label>
               <asp:TextBox runat="server" type="text" class="form-content" id="user" name="user"/>         
        <div class="form-border"></div>
        <label for="user-password" style="padding-top:22px">&nbsp;Contraseña
          </label>
           <asp:TextBox runat="server" type="password" class="form-content" ID="contra" name="contra"/>
        <div class="form-border"></div>

          <asp:Button CssClass="submit-btn" OnClick="click_Button"  ID="Button1" runat="server" Text="Ingresar" />

      </form>
    </div>
  </div>


      
   <center>
                   <footer class="my-5 pt-5 text-muted text-center text-small">
    <p class="mb-1" style="color: #fff;">&copy; 2019 Software O&B</p>
  </footer>

   </center>
        



        </div>
      
<style>
    a {
  text-decoration: none;
}
body {
  background: -webkit-linear-gradient(bottom, #2dbd6e, #a6f77b);
  background-repeat: no-repeat;
}
label {
  font-family: "Raleway", sans-serif;
  font-size: 11pt;
}
#forgot-pass {
  color: #2dbd6e;
  font-family: "Raleway", sans-serif;
  font-size: 10pt;
  margin-top: 3px;
  text-align: right;
}
#card {
  background: #fbfbfb;
  border-radius: 8px;
  box-shadow: 1px 2px 8px rgba(0, 0, 0, 0.65);
  height: 410px;
  margin: 6rem auto 8.1rem auto;
  width: 329px;
}
#card-content {
  padding: 12px 44px;
}
#card-title {
  font-family: "Raleway Thin", sans-serif;
  letter-spacing: 4px;
  padding-bottom: 23px;
  padding-top: 13px;
  text-align: center;
}
#signup {
  color: #2dbd6e;
  font-family: "Raleway", sans-serif;
  font-size: 10pt;
  margin-top: 16px;
  text-align: center;
}
.submit-btn {
  background: -webkit-linear-gradient(right, #a6f77b, #2dbd6e);
  border: none;
  border-radius: 21px;
  box-shadow: 0px 1px 8px #24c64f;
  cursor: pointer;
  color: white;
  font-family: "Raleway SemiBold", sans-serif;
  height: 42.3px;
  margin: 0 auto;
  margin-top: 50px;
  transition: 0.25s;
  width: 153px;
}
.submit-btn:hover {
  box-shadow: 0px 1px 18px #24c64f;
}
.form {
  align-items: left;
  display: flex;
  flex-direction: column;
}
.form-border {
  background: -webkit-linear-gradient(right, #a6f77b, #2ec06f);
  height: 1px;
  width: 100%;
}
.form-content {
  background: #fbfbfb;
  border: none;
  outline: none;
  padding-top: 14px;
}
.underline-title {
  background: -webkit-linear-gradient(right, #a6f77b, #2ec06f);
  height: 2px;
  margin: -1.1rem auto 0 auto;
  width: 89px;
}

</style>





    </body>




</html>