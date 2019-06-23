<%@ Page Language="C#" Title="Новые данные" AutoEventWireup="true" CodeBehind="New_Data.aspx.cs" Inherits="IS_technopark.Account.New_Data" MasterPageFile="~/Site.Master"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2 style="text-align:center; width: 1287px;">НОВЫЕ ДАННЫЕ</h2>
    <div style="float:right; text-align:left; margin-right:50px; margin-top:5px; font-size:13px">
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT TECHNOPARK.EMPLOYEES.FIO, TECHNOPARK.DIR_POSITION.DIR_POSITION, TECHNOPARK.EMPLOYEES.ID_EMPLOYEES FROM TECHNOPARK.DIR_POSITION INNER JOIN TECHNOPARK.EMPLOYEES ON TECHNOPARK.DIR_POSITION.ID_DIR_POSITION = TECHNOPARK.EMPLOYEES.POSITION WHERE (TECHNOPARK.EMPLOYEES.POSITION &lt;&gt; 3) ORDER BY TECHNOPARK.EMPLOYEES.FIO" UpdateCommand="UPDATE TECHNOPARK.EMPLOYEES SET FIO = 'qwe' WHERE 1=0"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" CellPadding="5" CellSpacing="3" PageSize="5" GridLines="Vertical" BackColor="White" BorderWidth="0px" DataKeyNames="ID_EMPLOYEES" OnRowUpdating="GridView1_RowUpdating">
        <Columns> 
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="34px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
        <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO" /> 
        <asp:BoundField DataField="DIR_POSITION" HeaderText="Должность" SortExpression="DIR_POSITION" /> 
        <asp:BoundField DataField="ID_EMPLOYEES" HeaderText="ID_EMPLOYEES" SortExpression="ID_EMPLOYEES" Visible="false"/>
        <asp:TemplateField ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center"> 
        <ItemTemplate> 
        <asp:ImageButton ImageUrl="~/img/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/> 
        <asp:ImageButton ImageUrl="~/img/delet.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Вы уверены, что хотите удалить данного сотрудника?');"/> 
        </ItemTemplate> 
        <EditItemTemplate> 
        <div style="width:50px"><asp:ImageButton ImageUrl="~/img/floppy-disk.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/> 
        <asp:ImageButton ImageUrl="~/img/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/></div> 
        </EditItemTemplate> 
        <ItemStyle Width="60px"></ItemStyle> 
        </asp:TemplateField> 
        </Columns> 
        <AlternatingRowStyle BackColor="#d2ecf9" /> 
        <EditRowStyle HorizontalAlign="Left" BackColor="#ffe8e6"/> 
        <FooterStyle BackColor="#CCCCCC" /> 
        <HeaderStyle BackColor="#8fc6f0" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="35px" Font-Size="17px" VerticalAlign="Middle" /> 
        <PagerStyle BackColor="#8fc6f0" ForeColor="White" HorizontalAlign="Center" /> 
    </asp:GridView>
    <br />
    <asp:Button ID="Button5" runat="server" Text="Сменить пароль" CssClass="active" Font-Size="10pt" BackColor="#CEE5F3" Height="27px" BorderStyle="Solid" BorderWidth="1px" />
    </div>
    <br />
    <h4 style="text-align:left; font-weight:600; margin-left:0px">Добавить нового сотрудника</h4>
    <div style="margin-left:0px; width: 1284px;">
    <div class='form-label' style="margin-left:0px; width:200px">
    <asp:Label ID="Label_Position" runat="server" Text="Должность"></asp:Label>
    </div>
    <div class='form-row' style="text-align:left; margin-left:0px;">
    <asp:DropDownList ID="DropDownList_Position" runat="server" CssClass="btn btn-default" Width="280px" Height="30px"></asp:DropDownList>
    </div>
    <br />
    <br />
    <div class='form-label' style="margin-left:0px; width:200px">
    <asp:Label ID="Label_FIO" runat="server" Text="ФИО сотрудника"></asp:Label>
    </div>
    <div class='form-row'>
    <asp:TextBox ID="TextBox2" runat="server" CssClass="btn btn-default" style="margin-right:20px; text-align:left; height:30px; Width:280px" ></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Добавить" Height="35px" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" OnClick="Button1_Click1" />
    </div>
    <br />
    <br />
    </div>
    <asp:Label ID="Label2" runat="server" Text="Директор:" Font-Size="13pt" Font-Bold="True" style="margin-right:10px;"></asp:Label>
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    <div style="margin-left:0px; width: 1284px;">
    <div class='form-label' style="margin-left:0px; width:200px">
    <asp:Label ID="Label1" runat="server" Text="Изменить ФИО"></asp:Label>
    </div>
    <div class='form-row' style="text-align:left; margin-left:0px;">
    <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="margin-right:20px; text-align:left; height:30px; Width:280px"></asp:TextBox> 
    <asp:Button ID="Button2" runat="server" Text="Изменить" Height="35px" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" OnClick="Button2_Click"/>
    </div>
    <br />
    <br />
    <br />
   </div>
    <br />
    <h4 style="text-align:left; font-weight:600; margin-left:0px">Добавить новое направление</h4>
    <div style="margin-left:0px; width: 1284px;">

    <div class='form-label' style="margin-left:0px; width:200px">
    <asp:Label ID="Label4" runat="server" Text="Направление"></asp:Label>
    </div>
    <div class='form-row' style="text-align:left; margin-left:0px;">
    </div>
    <asp:TextBox ID="TextBox3" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:20px; height:30px; Width:280px"></asp:TextBox>
    <asp:Button ID="Button3" runat="server" Text="Добавить" Height="35px" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3"/>
    </div>
    <br />
    <div class='form-label' style="margin-left:0px; width:200px">
    <asp:Label ID="Label5" runat="server" Text="Выберите направление"></asp:Label>
    </div>
    <div class='form-row' style="text-align:left; margin-left:0px;">
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="btn btn-default" Width="280px" Height="30px"></asp:DropDownList>
    </div>
    <br />
    <br />
    <div class='form-label' style="margin-left:0px; width:200px">
    <asp:Label ID="Label6" runat="server" Text="Проект"></asp:Label>
    </div>
    <div class='form-row' style="text-align:left; margin-left:0px;">
    <asp:TextBox ID="TextBox4" runat="server" CssClass="btn btn-default" style="text-align:left; margin-right:20px; height:30px; Width:280px"></asp:TextBox><asp:Button ID="Button4" runat="server" Text="Добавить" Height="35px" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3"/>
    </div>

    <div class='form-label' style="margin-left:0px; width:200px">
    </div>
    <div class='form-row' style="text-align:left; margin-left:0px;">
    </div>

 </asp:Content>