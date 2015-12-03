<%@ Page Title="" Language="C#" MasterPageFile="~/ICT4Rails.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ICT4Rails.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="jumbotron">
        <h1>Welkom!</h1>

        <p class="lead">
            Dit is de home pagina voor alle werknemers van ICT4Rails
        </p>

        <p><a href="Login.aspx" class="btn btn-primary btn-lg">Login &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>h2</h2>
            <ul>
                <li>een</li>
                <li>twee</li>
            </ul>
            <p>
                <a class="btn btn-default" href="Default.aspx">button &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Titel</h2>
            <p>
                Hallo
            </p>
            <p>
                <a class="btn btn-default" href="Default.aspx">Lees Meer &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Titel</h2>
            <p>
                Hey
            </p>
            <p>
                <a class="btn btn-default" href="Default.aspx">Lees meer &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
