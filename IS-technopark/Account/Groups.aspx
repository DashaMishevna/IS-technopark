<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Groups.aspx.cs" Inherits="IS_technopark.Account.Groups" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT FIO FROM TECHNOPARK.EMPLOYEES WHERE (POSITION = 2)"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand = "SELECT TECHNOPARK.LEARNER.ID_LEARNER, TECHNOPARK.LEARNER.FIO, TECHNOPARK.QUEUE.DATE_REGISTRATION, TECHNOPARK.LEARNER.CLASS, TECHNOPARK.LEARNER.SHIFT, TECHNOPARK.LEARNER.SCHOOL, TECHNOPARK.DIR_LABORATORIES.LABORATORY, TECHNOPARK.DIR_PROJECTS.TITLE FROM TECHNOPARK.LEARNER INNER JOIN TECHNOPARK.QUEUE ON TECHNOPARK.LEARNER.ID_LEARNER = TECHNOPARK.QUEUE.ID_LEARNER_Q INNER JOIN TECHNOPARK.DIR_PROJECTS ON TECHNOPARK.QUEUE.ID_PROJECT = TECHNOPARK.DIR_PROJECTS.ID_DIR_PROJECTS INNER JOIN TECHNOPARK.DIR_LABORATORIES ON TECHNOPARK.QUEUE.ID_LABORATORIES = TECHNOPARK.DIR_LABORATORIES.ID_LABORATORIES INNER JOIN TECHNOPARK.DIR_STATUS_LEARNER ON TECHNOPARK.QUEUE.ID_STATUS_L = TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER WHERE (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER &lt;&gt; 2) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER &lt;&gt; 6) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER &lt;&gt; 7) AND (TECHNOPARK.DIR_STATUS_LEARNER.ID_DIR_STATUS_LEARNER &lt;&gt; 8)"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand = "SELECT &quot;LABORATORY&quot; FROM &quot;DIR_LABORATORIES&quot;"></asp:SqlDataSource>
    <br>
    <h2 style="text-align:center"> ГРУППЫ </h2>
    <div style="float:right; text-align:left; margin-right:-150px; font-size:13px">
        <br>
        <h4 style="text-align:left; font-weight:600 ">Выберите обучающихся</h4>
        <br>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" style="font-size:13px; height:30px;" AllowPaging="True" DataKeyNames="ID_LEARNER" CellPadding="4" ForeColor="#333333" GridLines="None"  >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="35px" />
                </asp:TemplateField>
                <asp:BoundField DataField="ID_LEARNER" HeaderText="ID_LEARNER" SortExpression="ID_LEARNER" HeaderStyle-Width="205px" Visible="false" > <HeaderStyle Width="205px"></HeaderStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" > <HeaderStyle Width="110" HorizontalAlign="Right"></HeaderStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="DATE_REGISTRATION" HeaderText="ДАТА РЕГИСТРАЦИИ" SortExpression="DATE_REGISTRATION" HeaderStyle-Width="60" DataFormatString="{0:dd/MM/yyyy}"> <HeaderStyle Width="45px"></HeaderStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="CLASS" HeaderText="CLASS" SortExpression="CLASS" HeaderStyle-Width="60px"> <HeaderStyle Width="50px"></HeaderStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="SHIFT" HeaderText="SHIFT" SortExpression="SHIFT" HeaderStyle-Width="60px" > <HeaderStyle Width="50px"></HeaderStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="SCHOOL" HeaderText="SCHOOL" SortExpression="SCHOOL" HeaderStyle-Width="120px"> <HeaderStyle Width="120px"></HeaderStyle>
                 </asp:BoundField>
                <asp:BoundField DataField="LABORATORY" HeaderText="LABORATORY" SortExpression="LABORATORY" HeaderStyle-Width="105" ><HeaderStyle Width="105" />
                 </asp:BoundField>
                <asp:BoundField DataField="TITLE" HeaderText="TITLE" SortExpression="TITLE" HeaderStyle-Width="225"> <HeaderStyle Width="225px"></HeaderStyle>
                </asp:BoundField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle HorizontalAlign="Center" BackColor="#A5D1F3" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle Height="30px" BackColor="#CEE5F3" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
            
    </div>

    <div style="float:left; margin-left:-170px;"> 
        <h4 style="text-align:left; font-weight:600 ">Данные о группе</h4>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label2" runat="server" Text="ФИО Преподавателя*"></asp:Label>
        </div>
        <div class="form-row" style="width:250px;">
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" CssClass="btn btn-default" DataTextField="FIO" DataValueField="FIO" AutoPostBack="True" Width="200px"> </asp:DropDownList>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label3" runat="server" Text="Направление *"></asp:Label>
        </div>
        <div class="form-row" style="width:250px;">
            <asp:DropDownList ID="DropDownList2" runat="server" style="max-width:200px" CssClass="btn btn-default" AutoPostBack="True" DataTextField="LABORATORY" DataValueField="LABORATORY" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"  Height="30px" Width="225px"></asp:DropDownList>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label4" runat="server" Text="Проект *"></asp:Label>
        </div>
        <div class='form-row'style="width:300px;" >
            <asp:DropDownList ID="DropDownList3" runat="server" style="max-width:200px" CssClass="btn btn-default" AutoPostBack="True"  Width="200px"  Height="30px"></asp:DropDownList>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label5" runat="server" Text="Шифр группы*"></asp:Label>
        </div>
        <div class='form-row' style="width:300px;"> 
            <asp:TextBox ID="TextBox1" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label6" runat="server" Text="Тема проекта"></asp:Label>
        </div>
        <div class='form-row' style="width:300px;">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label7" runat="server" Text="Время занятий"></asp:Label>
        </div>
        <div class='form-row' style="width:300px;">
            <asp:TextBox ID="TextBox3" runat="server" CssClass="btn btn-default" style="text-align:left"></asp:TextBox>
        </div>
        <br>
        <br>
        <div style="margin-top: 4px; float:left; width:200px; height:30px; font-size:16px;">
            <asp:Label ID="Label8" runat="server" Text="Дополнительный поиск по интересам"></asp:Label>
        </div>
        <div class="form-row" style="width:250px;">
            <asp:CheckBox ID="CheckBox1" runat="server"  Width="15px" Height="15px"  TextAlign="Left"   Text=" " AutoPostBack="True" Font-Strikeout="False" BackColor="#FFFF99" />
            <%--<asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="SqlDataSource3" CssClass="btn btn-default" DataTextField="LABORATORY" DataValueField="LABORATORY" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged"> </asp:DropDownList>--%>
        </div>
        <br>
        <br>
 </div>

    <div class="form-group" style=" text-align:center; margin-top:500px">
        <asp:Button ID="Button1" runat="server" Text="Добавить" Width="225px" Height="40px" CssClass="btn btn-default" Font-Size="13pt" BackColor="#CEE5F3"  />
        <br/>
        <br/>
        <asp:Label ID="Label1" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
    </div>


 </asp:Content>