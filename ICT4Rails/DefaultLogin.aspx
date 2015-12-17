<%@ Page Title="" Language="C#" MasterPageFile="~/ICT4Rails.Master" AutoEventWireup="true" CodeBehind="DefaultLogin.aspx.cs" Inherits="ICT4Rails.DefaultLogin" %>

<asp:Content ID="DefaultLogin" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div>
        <h1>Kies je systeem</h1><br />

        <div class="row">
            <div class="col-md-1"></div>

            <div class="col-md-2"><a href="Beheer.aspx" class="btn btn-primary btn-lg btn-width">Beheer &raquo;</a></div>
            <div class="col-md-2"><a href="Schoonmaak.aspx" class="btn btn-primary btn-lg btn-width">Schoonmaak &raquo;</a></div>
            <div class="col-md-2"><a href="Techniek.aspx" class="btn btn-primary btn-lg btn-width">Techniek &raquo;</a></div>
            <div class="col-md-2"><a href="InUitRij.aspx" class="btn btn-primary btn-lg btn-width">In / Uit Rij &raquo;</a></div>
            <div class="col-md-2"><a href="Admin.aspx" class="btn btn-primary btn-lg btn-width">Admin &raquo;</a></div>

            <div class="col-md-1"></div>
        </div>
    </div>

</asp:Content>
