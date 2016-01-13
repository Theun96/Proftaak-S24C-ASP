<%@ Page Title="" Language="C#" MasterPageFile="~/ICT4Rails.Master" AutoEventWireup="true" CodeBehind="Beheer.aspx.cs" Inherits="ICT4Rails.Beheer" %>

<asp:Content ID="Beheer" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="tableStyle">
        <asp:Table ID="tblBeheer" runat="server" CellPadding="10" GridLines="Both" HorizontalAlign="Center">
            
        </asp:Table>
    </div>

    <asp:Button ID="btnSimulation" runat="server" Text="Simulatie" CssClass="btn btn-primary" OnClick="btnSimulation_Click"/>
</asp:Content>
