<%@ Page  Title="HomePage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="IS_technopark.HomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
<asp:SqlDataSource ID="Technopark" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM &quot;LEARNER&quot;" UpdateCommand="UPDATE TECHNOPARK.LEARNER SET FIO = FIO, CLASS = CLASS, BIRTHDAY = BIRTHDAY, SCHOOL = SCHOOL, PHONE = PHONE, SHIFT = SHIFT, E_MAIL = E_MAIL, INTERESTS = INTERESTS, COMMENTS = COMMENTS WHERE (ID_LEARNER = ID_LEARNER)" >
    <UpdateParameters>
        <asp:ControlParameter ControlID="Technopark" Name="newparameter" PropertyName="SelectedValue" />
    </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataSourceID="Technopark" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="ID_LEARNER">
        <Columns>
            <asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" SortExpression="ID_LEARNER" ReadOnly="True" Visible="False" />
            <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" />
            <asp:BoundField DataField="CLASS" HeaderText="CLASS" SortExpression="CLASS" />
            <asp:BoundField DataField="BIRTHDAY" HeaderText="BIRTHDAY" SortExpression="BIRTHDAY" />
            <asp:BoundField DataField="SCHOOL" HeaderText="SCHOOL" SortExpression="SCHOOL" />
            <asp:BoundField DataField="PHONE" HeaderText="PHONE" SortExpression="PHONE" />
            <asp:BoundField DataField="SHIFT" HeaderText="SHIFT" SortExpression="SHIFT" />
            <asp:BoundField DataField="E_MAIL" HeaderText="E_MAIL" SortExpression="E_MAIL" />
            <asp:BoundField DataField="INTERESTS" HeaderText="INTERESTS" SortExpression="INTERESTS" />
            <asp:BoundField DataField="COMMENTS" HeaderText="COMMENTS" SortExpression="COMMENTS" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/pen.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxFirst" Text='<%# Eval("FirstName")%>' runat="server"/>
                </EditItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ImageUrl="~/img/home.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton ImageUrl="~/img/plus.png" runat="server" CommandName="Add" ToolTip="Add" Width="20px" Height="20px"/>
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
