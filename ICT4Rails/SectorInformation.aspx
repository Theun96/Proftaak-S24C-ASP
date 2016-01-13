<%@ Page Title="" Language="C#" MasterPageFile="~/ICT4Rails.Master" AutoEventWireup="true" CodeBehind="SectorInformation.aspx.cs" Inherits="ICT4Rails.SectorInformation" %>

<asp:Content ID="SectorInformation" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="row">

        <div class="col-md-5">

            <div class="jumbotron">
                <div class="btn-width">
                    <asp:Label ID="lblBlokkade" runat="server" Text="Blokkeer Sector:"/>
                </div>

                <div class="btn-width">
                    <asp:Button ID="btnBlokkeren" runat="server" CssClass="btn-width form-control" Text="Blokkeren" OnClick="btnBlokkeren_Click" />
                </div>
            </div>


        </div>

        <div class="col-md-2">
        </div>

        <div class="col-md-5">
            <div class="jumbotron">
                
                <div class="btn-width">
                    <asp:Label ID="lblTramNummerToevoegen" runat="server" Text="Tram Toevoegen:"/>
                </div>
                
                <div>
                    <asp:TextBox ID="tbTramToevoegen" runat="server" CssClass="btn-width form-control" Text=""/>
                </div>

                <div>
                    <asp:Button ID="btnTramToevoegen" runat="server" CssClass="btn-width form-control" Text="Toevoegen" OnClick="btnTramToevoegen_Click" />
                </div>
                
                <div>
                    <asp:Button ID="btnTramVerwijderen" runat="server" CssClass="btn-width form-control" Text="Tram Verwijderen" OnClick="btnTramVerwijderen_Click"/>
                </div>
            </div>

        </div>

        <asp:Button ID="btnTerug" runat="server" CssClass="form-control" Text="Terug" OnClick="btnTerug_Click" />
    </div>

</asp:Content>
