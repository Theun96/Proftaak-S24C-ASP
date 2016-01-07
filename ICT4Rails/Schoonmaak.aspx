<%@ Page Title="" Language="C#" MasterPageFile="~/ICT4Rails.Master" AutoEventWireup="true" CodeBehind="Schoonmaak.aspx.cs" Inherits="ICT4Rails.Schoonmaak" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <table class="table table-striped" style="width: 100%;">
            <thead>
                <tr>
                    <th>Tram</th>
                    <th>Begin datum</th>
                    <th>Eind datum</th>
                    <th>Schoonmaker</th>
                    <th>Klaar</th>
                    <th>Opmerking</th>
                </tr>
            </thead>
            <tbody>
            
            </tbody>
        </table>
        </div>
        <div class="col-md-3  col-md-offset-1">
            <asp:DropDownList ID="DropDownUsers" runat="server" cssclass="form-control dropdown"></asp:DropDownList>
            <asp:Button ID="ButtonCleaned" runat="server" Text="Schoongemaakt" cssclass="form-control" />
        </div>
        <div class="col-md-3  col-md-offset-4">
            <input type="text" value="1/1/2016" readonly="readonly" name="datepicker" id="datepicker" class="datepicker form-control"/>
            <asp:Button ID="ButtonSaveEndDate" runat="server" Text="Einddatum opslaan" cssclass="form-control" />
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $(".datepicker").datepicker();
        });
    </script>
</asp:Content>
