<%@ Page Title="" Language="C#" MasterPageFile="~/ICT4Rails.Master" AutoEventWireup="true" CodeBehind="SectorInformation.aspx.cs" Inherits="ICT4Rails.SectorInformation" %>

<asp:Content ID="SectorInformation" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="row">
        <div class="col-md-4 jumbotron">
            <asp:Label ID="lblTramNummer" runat="server" Text="Tram Reserveren"></asp:Label>


            <div>
                <asp:TextBox ID="tbTramNummer" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Button ID="btnReserveer" runat="server" Text="Reserveer" />
            </div>

        </div>

        <div class="col-md-4 jumbotron">

            <div>
                <asp:Label ID="lblBlokkade" runat="server" Text="Blokkeer Sector:"></asp:Label>
            </div>

            <div>
                <asp:Button ID="btnBlokkeren" runat="server" Text="Blokkeren" OnClick="btnBlokkeren_Click" />
            </div>
        </div>

        <div class="col-md-4 jumbotron">
            <asp:Label ID="lblTramNummerToevoegen" runat="server" Text="Tram Toevoegen"></asp:Label>


            <div>
                <asp:TextBox ID="tbTramToevoegen" runat="server"></asp:TextBox>
            </div>

            <div>
                <asp:Button ID="btnTramToevoegen" runat="server" Text="Toevoegen" />
            </div>
            
        </div>
        
        <asp:Button ID="btnTerug" runat="server" Text="Terug" OnClick="btnTerug_Click" />
    </div>




</asp:Content>
