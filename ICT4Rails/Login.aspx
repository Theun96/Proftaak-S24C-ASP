<%@ Page Title="" Language="C#" MasterPageFile="~/ICT4Rails.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ICT4Rails.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <div class="container">
        <div class="col-md-4"></div>
        <div class="col-md-4">
            <h2 class="form-signin-heading">Log in uw account</h2>         
            <asp:TextBox runat="server" id="txtUsername" CssClass="form-control" placeholder="Gebruikersnaam" />
            <asp:TextBox runat="server" id="txtPassword" Cssclass="form-control" placeholder="Wachtwoord" />
            <div class="checkbox">
              <label>
                <input type="checkbox" value="remember-me" /> Onthoud mij
              </label>
            </div>
            <asp:Button cssclass="btn btn-lg btn-primary btn-block" ID="btnLogin" runat="server" Text="Inloggen" OnClick="btnLogin_Click" />
        </div>
        <div class="col-md-4"></div>
    </div> <!-- /container -->
</asp:Content>
