<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Universidades_y_Personas._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Ingreso de Datos</h1>
        <h3>Universidad: <asp:TextBox ID="uni_txt" runat="server"></asp:TextBox></h3>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe Ingresar Universidad" ControlToValidate="uni_txt">Universidad requerida</asp:RequiredFieldValidator>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="Button1" runat="server" CssClass="bg-primary" Text="Alumnos" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" CssClass="bg-primary" Text="Profesores" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" CssClass="bg-primary" Text="Personal Administrativo" OnClick="Button3_Click" />
         </div>
        <h3> <asp:Label ID="persona_lb" runat="server" Text="Datos Persona:"></asp:Label></h3>
        Nombre: <asp:TextBox ID="nombreA_txt" runat="server"></asp:TextBox>
        Apellido: <asp:TextBox ID="apellidoA_txt" runat="server"></asp:TextBox>
        Dirección: <asp:TextBox ID="direccionA_txt" runat="server"></asp:TextBox>
            <br />
        Fecha de Nacimiento<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" VisibleDate="1999-01-01" Width="350px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            <TodayDayStyle BackColor="#CCCCCC" />
        </asp:Calendar>
            <asp:Label ID="carneal_lb" runat="server" Text="Carné:" Visible="False"></asp:Label>
            <asp:TextBox ID="carneal_txt" runat="server" Visible="False"></asp:TextBox>
            <asp:Label ID="id_lb" runat="server" Text="ID:" Visible="False"></asp:Label>
            <asp:TextBox ID="id_txt" runat="server" Visible="False"></asp:TextBox>
            <asp:Label ID="titulo_lb" runat="server" Text="Título Universitario:" Visible="False"></asp:Label>
            <asp:TextBox ID="titulo_txt" runat="server" Visible="False"></asp:TextBox>
            <asp:Label ID="igss_lb" runat="server" Text="No. IGSS:" Visible="False"></asp:Label>
            <asp:TextBox ID="igss_txt" runat="server" Visible="False"></asp:TextBox>
            <asp:Label ID="profesion_lb" runat="server" Text="Profesión:" Visible="False"></asp:Label>
            <asp:TextBox ID="profesion_txt" runat="server" Visible="False"></asp:TextBox>
            <br />
            <asp:Label ID="iniciolab_lb" runat="server" Text="Inicio Labores:" Visible="False"></asp:Label>

            <asp:Calendar ID="iniciolab_cd" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Visible="False" VisibleDate="1999-01-01" Width="330px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                <DayStyle BackColor="#CCCCCC" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                <TodayDayStyle BackColor="#999999" ForeColor="White" />
            </asp:Calendar>
            <br />
            <asp:Label ID="finallab_lb" runat="server" Text="Final de Labores:" Visible="False"></asp:Label>

            <asp:Calendar ID="finallab_cd" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Visible="False" VisibleDate="1999-01-01" Width="330px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                <DayStyle BackColor="#CCCCCC" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                <TodayDayStyle BackColor="#999999" ForeColor="White" />
            </asp:Calendar>
    </div>

</asp:Content>
