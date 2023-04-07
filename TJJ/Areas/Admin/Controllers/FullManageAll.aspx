<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FullManageAll.aspx.cs" Inherits="TJJ.Areas.Admin.Controllers.FullManageAll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Full Manage All</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>&ensp;</p>
            <asp:Button ID="btn_back" runat="server" Height="38px" OnClick="btn_back_Click" Text="Back To Main Menu" Width="162px" />
            <br />
            <br />
            <div style="width: 100%; height: auto; overflow: scroll;">
                <div style="width: 130%; background-color: rgba(0, 0, 0, 0.29)">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                            <asp:BoundField DataField="fname" HeaderText="fname" SortExpression="fname" />
                            <asp:BoundField DataField="lname" HeaderText="lname" SortExpression="lname" />
                            <asp:BoundField DataField="code_melli" HeaderText="code_melli" SortExpression="code_melli" />
                            <asp:BoundField DataField="birthday_date" HeaderText="birthday_date" SortExpression="birthday_date" />
                            <asp:BoundField DataField="user_type" HeaderText="user_type" SortExpression="user_type" />
                            <asp:BoundField DataField="inviter_code" HeaderText="inviter_code" SortExpression="inviter_code" />
                            <asp:BoundField DataField="register_date_time" HeaderText="register_date_time" SortExpression="register_date_time" />
                            <asp:BoundField DataField="gold_charge" HeaderText="gold_charge" SortExpression="gold_charge" />
                            <asp:BoundField DataField="rial_charge" HeaderText="rial_charge" SortExpression="rial_charge" />
                            <asp:BoundField DataField="dest_Account_Number" HeaderText="dest_Account_Number" SortExpression="dest_Account_Number" />
                            <asp:BoundField DataField="dest_Card_Number" HeaderText="dest_Card_Number" SortExpression="dest_Card_Number" />
                            <asp:CheckBoxField DataField="confirm_Account_Bank" HeaderText="confirm_Account_Bank" SortExpression="confirm_Account_Bank" />
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            <asp:CheckBoxField DataField="EmailConfirmed" HeaderText="EmailConfirmed" SortExpression="EmailConfirmed" />
                            <asp:BoundField DataField="PasswordHash" HeaderText="PasswordHash" SortExpression="PasswordHash" />
                            <asp:BoundField DataField="SecurityStamp" HeaderText="SecurityStamp" SortExpression="SecurityStamp" />
                            <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                            <asp:CheckBoxField DataField="PhoneNumberConfirmed" HeaderText="PhoneNumberConfirmed" SortExpression="PhoneNumberConfirmed" />
                            <asp:CheckBoxField DataField="TwoFactorEnabled" HeaderText="TwoFactorEnabled" SortExpression="TwoFactorEnabled" />
                            <asp:BoundField DataField="LockoutEndDateUtc" HeaderText="LockoutEndDateUtc" SortExpression="LockoutEndDateUtc" />
                            <asp:CheckBoxField DataField="LockoutEnabled" HeaderText="LockoutEnabled" SortExpression="LockoutEnabled" />
                            <asp:BoundField DataField="AccessFailedCount" HeaderText="AccessFailedCount" SortExpression="AccessFailedCount" />
                            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [AspNetUsers] WHERE [Id] = @Id" InsertCommand="INSERT INTO [AspNetUsers] ([Id], [fname], [lname], [code_melli], [birthday_date], [user_type], [inviter_code], [register_date_time], [gold_charge], [rial_charge], [dest_Account_Number], [dest_Card_Number], [confirm_Account_Bank], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (@Id, @fname, @lname, @code_melli, @birthday_date, @user_type, @inviter_code, @register_date_time, @gold_charge, @rial_charge, @dest_Account_Number, @dest_Card_Number, @confirm_Account_Bank, @Email, @EmailConfirmed, @PasswordHash, @SecurityStamp, @PhoneNumber, @PhoneNumberConfirmed, @TwoFactorEnabled, @LockoutEndDateUtc, @LockoutEnabled, @AccessFailedCount, @UserName)" ProviderName="<%$ ConnectionStrings:DefaultConnection.ProviderName %>" SelectCommand="SELECT [Id], [fname], [lname], [code_melli], [birthday_date], [user_type], [inviter_code], [register_date_time], [gold_charge], [rial_charge], [dest_Account_Number], [dest_Card_Number], [confirm_Account_Bank], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName] FROM [AspNetUsers]" UpdateCommand="UPDATE [AspNetUsers] SET [fname] = @fname, [lname] = @lname, [code_melli] = @code_melli, [birthday_date] = @birthday_date, [user_type] = @user_type, [inviter_code] = @inviter_code, [register_date_time] = @register_date_time, [gold_charge] = @gold_charge, [rial_charge] = @rial_charge, [dest_Account_Number] = @dest_Account_Number, [dest_Card_Number] = @dest_Card_Number, [confirm_Account_Bank] = @confirm_Account_Bank, [Email] = @Email, [EmailConfirmed] = @EmailConfirmed, [PasswordHash] = @PasswordHash, [SecurityStamp] = @SecurityStamp, [PhoneNumber] = @PhoneNumber, [PhoneNumberConfirmed] = @PhoneNumberConfirmed, [TwoFactorEnabled] = @TwoFactorEnabled, [LockoutEndDateUtc] = @LockoutEndDateUtc, [LockoutEnabled] = @LockoutEnabled, [AccessFailedCount] = @AccessFailedCount, [UserName] = @UserName WHERE [Id] = @Id">
                        <DeleteParameters>
                            <asp:Parameter Name="Id" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Id" Type="String" />
                            <asp:Parameter Name="fname" Type="String" />
                            <asp:Parameter Name="lname" Type="String" />
                            <asp:Parameter Name="code_melli" Type="String" />
                            <asp:Parameter Name="birthday_date" Type="String" />
                            <asp:Parameter Name="user_type" Type="Int16" />
                            <asp:Parameter Name="inviter_code" Type="String" />
                            <asp:Parameter DbType="DateTime2" Name="register_date_time" />
                            <asp:Parameter Name="gold_charge" Type="Double" />
                            <asp:Parameter Name="rial_charge" Type="Double" />
                            <asp:Parameter Name="dest_Account_Number" Type="String" />
                            <asp:Parameter Name="dest_Card_Number" Type="String" />
                            <asp:Parameter Name="confirm_Account_Bank" Type="Boolean" />
                            <asp:Parameter Name="Email" Type="String" />
                            <asp:Parameter Name="EmailConfirmed" Type="Boolean" />
                            <asp:Parameter Name="PasswordHash" Type="String" />
                            <asp:Parameter Name="SecurityStamp" Type="String" />
                            <asp:Parameter Name="PhoneNumber" Type="String" />
                            <asp:Parameter Name="PhoneNumberConfirmed" Type="Boolean" />
                            <asp:Parameter Name="TwoFactorEnabled" Type="Boolean" />
                            <asp:Parameter Name="LockoutEndDateUtc" Type="DateTime" />
                            <asp:Parameter Name="LockoutEnabled" Type="Boolean" />
                            <asp:Parameter Name="AccessFailedCount" Type="Int32" />
                            <asp:Parameter Name="UserName" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="fname" Type="String" />
                            <asp:Parameter Name="lname" Type="String" />
                            <asp:Parameter Name="code_melli" Type="String" />
                            <asp:Parameter Name="birthday_date" Type="String" />
                            <asp:Parameter Name="user_type" Type="Int16" />
                            <asp:Parameter Name="inviter_code" Type="String" />
                            <asp:Parameter DbType="DateTime2" Name="register_date_time" />
                            <asp:Parameter Name="gold_charge" Type="Double" />
                            <asp:Parameter Name="rial_charge" Type="Double" />
                            <asp:Parameter Name="dest_Account_Number" Type="String" />
                            <asp:Parameter Name="dest_Card_Number" Type="String" />
                            <asp:Parameter Name="confirm_Account_Bank" Type="Boolean" />
                            <asp:Parameter Name="Email" Type="String" />
                            <asp:Parameter Name="EmailConfirmed" Type="Boolean" />
                            <asp:Parameter Name="PasswordHash" Type="String" />
                            <asp:Parameter Name="SecurityStamp" Type="String" />
                            <asp:Parameter Name="PhoneNumber" Type="String" />
                            <asp:Parameter Name="PhoneNumberConfirmed" Type="Boolean" />
                            <asp:Parameter Name="TwoFactorEnabled" Type="Boolean" />
                            <asp:Parameter Name="LockoutEndDateUtc" Type="DateTime" />
                            <asp:Parameter Name="LockoutEnabled" Type="Boolean" />
                            <asp:Parameter Name="AccessFailedCount" Type="Int32" />
                            <asp:Parameter Name="UserName" Type="String" />
                            <asp:Parameter Name="Id" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>

                </div>
            </div>
            <br />
            <br />

            <div style="width: 100%; height: auto; overflow: scroll;">
                <div style="width: 110%; background-color: rgba(0, 0, 0, 0.29)">

                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="deposit_id" DataSourceID="SqlDataSource2" EmptyDataText="There are no data records to display." ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                            <asp:BoundField DataField="deposit_id" HeaderText="deposit_id" InsertVisible="False" ReadOnly="True" SortExpression="deposit_id" />
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:BoundField DataField="deposit_status" HeaderText="deposit_status" SortExpression="deposit_status" />
                            <asp:BoundField DataField="deposit_money_value" HeaderText="deposit_money_value" SortExpression="deposit_money_value" />
                            <asp:BoundField DataField="deposit_date_time" HeaderText="deposit_date_time" SortExpression="deposit_date_time" />
                            <asp:BoundField DataField="deposit_tracking_code" HeaderText="deposit_tracking_code" SortExpression="deposit_tracking_code" />
                            <asp:BoundField DataField="deposit_dest_account_number" HeaderText="deposit_dest_account_number" SortExpression="deposit_dest_account_number" />
                            <asp:BoundField DataField="deposit_img" HeaderText="deposit_img" SortExpression="deposit_img" />
                            <asp:BoundField DataField="deposit_comment" HeaderText="deposit_comment" SortExpression="deposit_comment" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [tbl_Deposits] WHERE [deposit_id] = @deposit_id" InsertCommand="INSERT INTO [tbl_Deposits] ([Id], [deposit_status], [deposit_money_value], [deposit_date_time], [deposit_tracking_code], [deposit_dest_account_number], [deposit_img], [deposit_comment]) VALUES (@Id, @deposit_status, @deposit_money_value, @deposit_date_time, @deposit_tracking_code, @deposit_dest_account_number, @deposit_img, @deposit_comment)" ProviderName="<%$ ConnectionStrings:DefaultConnection.ProviderName %>" SelectCommand="SELECT [deposit_id], [Id], [deposit_status], [deposit_money_value], [deposit_date_time], [deposit_tracking_code], [deposit_dest_account_number], [deposit_img], [deposit_comment] FROM [tbl_Deposits]" UpdateCommand="UPDATE [tbl_Deposits] SET [Id] = @Id, [deposit_status] = @deposit_status, [deposit_money_value] = @deposit_money_value, [deposit_date_time] = @deposit_date_time, [deposit_tracking_code] = @deposit_tracking_code, [deposit_dest_account_number] = @deposit_dest_account_number, [deposit_img] = @deposit_img, [deposit_comment] = @deposit_comment WHERE [deposit_id] = @deposit_id">
                        <DeleteParameters>
                            <asp:Parameter Name="deposit_id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Id" Type="String" />
                            <asp:Parameter Name="deposit_status" Type="Int16" />
                            <asp:Parameter Name="deposit_money_value" Type="Double" />
                            <asp:Parameter DbType="DateTime2" Name="deposit_date_time" />
                            <asp:Parameter Name="deposit_tracking_code" Type="String" />
                            <asp:Parameter Name="deposit_dest_account_number" Type="String" />
                            <asp:Parameter Name="deposit_img" Type="String" />
                            <asp:Parameter Name="deposit_comment" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Id" Type="String" />
                            <asp:Parameter Name="deposit_status" Type="Int16" />
                            <asp:Parameter Name="deposit_money_value" Type="Double" />
                            <asp:Parameter DbType="DateTime2" Name="deposit_date_time" />
                            <asp:Parameter Name="deposit_tracking_code" Type="String" />
                            <asp:Parameter Name="deposit_dest_account_number" Type="String" />
                            <asp:Parameter Name="deposit_img" Type="String" />
                            <asp:Parameter Name="deposit_comment" Type="String" />
                            <asp:Parameter Name="deposit_id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>

                </div>
            </div>
            <br />
            <br />

            <div style="width: 100%; height: auto; overflow: scroll;">
                <div style="width: auto; background-color: rgba(0, 0, 0, 0.29)">
                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="req_id" DataSourceID="SqlDataSource3" EmptyDataText="There are no data records to display." ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                            <asp:BoundField DataField="req_id" HeaderText="req_id" ReadOnly="True" SortExpression="req_id" />
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:BoundField DataField="req_status" HeaderText="req_status" SortExpression="req_status" />
                            <asp:BoundField DataField="sell_gold_value" HeaderText="sell_gold_value" SortExpression="sell_gold_value" />
                            <asp:BoundField DataField="req_money_value" HeaderText="req_money_value" SortExpression="req_money_value" />
                            <asp:BoundField DataField="sell_date_time" HeaderText="sell_date_time" SortExpression="sell_date_time" />
                            <asp:BoundField DataField="sell_tracking_code" HeaderText="sell_tracking_code" SortExpression="sell_tracking_code" />
                            <asp:BoundField DataField="sell_img" HeaderText="sell_img" SortExpression="sell_img" />
                            <asp:BoundField DataField="sell_user_comment" HeaderText="sell_user_comment" SortExpression="sell_user_comment" />
                            <asp:BoundField DataField="sell_admin_comment" HeaderText="sell_admin_comment" SortExpression="sell_admin_comment" />
                        </Columns>
                        <EditRowStyle BackColor="#7C6F57" />
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#E3EAEB" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F8FAFA" />
                        <SortedAscendingHeaderStyle BackColor="#246B61" />
                        <SortedDescendingCellStyle BackColor="#D4DFE1" />
                        <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [tbl_Request_Money] WHERE [req_id] = @req_id" InsertCommand="INSERT INTO [tbl_Request_Money] ([Id], [req_status], [sell_gold_value], [req_money_value], [sell_date_time], [sell_tracking_code], [sell_img], [sell_user_comment], [sell_admin_comment]) VALUES (@Id, @req_status, @sell_gold_value, @req_money_value, @sell_date_time, @sell_tracking_code, @sell_img, @sell_user_comment, @sell_admin_comment)" ProviderName="<%$ ConnectionStrings:DefaultConnection.ProviderName %>" SelectCommand="SELECT [req_id], [Id], [req_status], [sell_gold_value], [req_money_value], [sell_date_time], [sell_tracking_code], [sell_img], [sell_user_comment], [sell_admin_comment] FROM [tbl_Request_Money]" UpdateCommand="UPDATE [tbl_Request_Money] SET [Id] = @Id, [req_status] = @req_status, [sell_gold_value] = @sell_gold_value, [req_money_value] = @req_money_value, [sell_date_time] = @sell_date_time, [sell_tracking_code] = @sell_tracking_code, [sell_img] = @sell_img, [sell_user_comment] = @sell_user_comment, [sell_admin_comment] = @sell_admin_comment WHERE [req_id] = @req_id">
                        <DeleteParameters>
                            <asp:Parameter Name="req_id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Id" Type="String" />
                            <asp:Parameter Name="req_status" Type="Int16" />
                            <asp:Parameter Name="sell_gold_value" Type="Single" />
                            <asp:Parameter Name="req_money_value" Type="Double" />
                            <asp:Parameter Name="sell_date_time" Type="DateTime" />
                            <asp:Parameter Name="sell_tracking_code" Type="String" />
                            <asp:Parameter Name="sell_img" Type="String" />
                            <asp:Parameter Name="sell_user_comment" Type="String" />
                            <asp:Parameter Name="sell_admin_comment" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Id" Type="String" />
                            <asp:Parameter Name="req_status" Type="Int16" />
                            <asp:Parameter Name="sell_gold_value" Type="Single" />
                            <asp:Parameter Name="req_money_value" Type="Double" />
                            <asp:Parameter Name="sell_date_time" Type="DateTime" />
                            <asp:Parameter Name="sell_tracking_code" Type="String" />
                            <asp:Parameter Name="sell_img" Type="String" />
                            <asp:Parameter Name="sell_user_comment" Type="String" />
                            <asp:Parameter Name="sell_admin_comment" Type="String" />
                            <asp:Parameter Name="req_id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 100%; height: auto; overflow: scroll;">
                <div style="width: auto; background-color: rgba(0, 0, 0, 0.29)">
                    <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ticket_id" DataSourceID="SqlDataSource4" EmptyDataText="There are no data records to display." ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                            <asp:BoundField DataField="ticket_id" HeaderText="ticket_id" ReadOnly="True" SortExpression="ticket_id" />
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:BoundField DataField="ticket_answer_id" HeaderText="ticket_answer_id" SortExpression="ticket_answer_id" />
                            <asp:BoundField DataField="ticket_date_time" HeaderText="ticket_date_time" SortExpression="ticket_date_time" />
                            <asp:BoundField DataField="ticket_subject" HeaderText="ticket_subject" SortExpression="ticket_subject" />
                            <asp:BoundField DataField="ticket_desc" HeaderText="ticket_desc" SortExpression="ticket_desc" />
                            <asp:CheckBoxField DataField="read_ticket" HeaderText="read_ticket" SortExpression="read_ticket" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [tbl_Tickets] WHERE [ticket_id] = @ticket_id" InsertCommand="INSERT INTO [tbl_Tickets] ([Id], [ticket_answer_id], [ticket_date_time], [ticket_subject], [ticket_desc], [read_ticket]) VALUES (@Id, @ticket_answer_id, @ticket_date_time, @ticket_subject, @ticket_desc, @read_ticket)" ProviderName="<%$ ConnectionStrings:DefaultConnection.ProviderName %>" SelectCommand="SELECT [ticket_id], [Id], [ticket_answer_id], [ticket_date_time], [ticket_subject], [ticket_desc], [read_ticket] FROM [tbl_Tickets]" UpdateCommand="UPDATE [tbl_Tickets] SET [Id] = @Id, [ticket_answer_id] = @ticket_answer_id, [ticket_date_time] = @ticket_date_time, [ticket_subject] = @ticket_subject, [ticket_desc] = @ticket_desc, [read_ticket] = @read_ticket WHERE [ticket_id] = @ticket_id">
                        <DeleteParameters>
                            <asp:Parameter Name="ticket_id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Id" Type="String" />
                            <asp:Parameter Name="ticket_answer_id" Type="Int32" />
                            <asp:Parameter Name="ticket_date_time" Type="DateTime" />
                            <asp:Parameter Name="ticket_subject" Type="String" />
                            <asp:Parameter Name="ticket_desc" Type="String" />
                            <asp:Parameter Name="read_ticket" Type="Boolean" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Id" Type="String" />
                            <asp:Parameter Name="ticket_answer_id" Type="Int32" />
                            <asp:Parameter Name="ticket_date_time" Type="DateTime" />
                            <asp:Parameter Name="ticket_subject" Type="String" />
                            <asp:Parameter Name="ticket_desc" Type="String" />
                            <asp:Parameter Name="read_ticket" Type="Boolean" />
                            <asp:Parameter Name="ticket_id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 100%; height: 400px; overflow: scroll;">
                <div style="width: auto; background-color: rgba(0, 0, 0, 0.29)">
                    <asp:GridView ID="GridView6" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="UserId,RoleId" DataSourceID="SqlDataSource6" EmptyDataText="There are no data records to display." GridLines="None">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" />
                            <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" SortExpression="UserId" />
                            <asp:BoundField DataField="RoleId" HeaderText="RoleId" ReadOnly="True" SortExpression="RoleId" />
                        </Columns>
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [AspNetUserRoles] WHERE [UserId] = @UserId AND [RoleId] = @RoleId" InsertCommand="INSERT INTO [AspNetUserRoles] ([UserId], [RoleId]) VALUES (@UserId, @RoleId)" ProviderName="<%$ ConnectionStrings:DefaultConnection.ProviderName %>" SelectCommand="SELECT [UserId], [RoleId] FROM [AspNetUserRoles]">
                        <DeleteParameters>
                            <asp:Parameter Name="UserId" Type="String" />
                            <asp:Parameter Name="RoleId" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="UserId" Type="String" />
                            <asp:Parameter Name="RoleId" Type="String" />
                        </InsertParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <br />
            <br />
            <div style="width: 100%; height: auto; overflow: scroll;">
                <div style="width: auto; background-color: rgba(0, 0, 0, 0.29)">
                    <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ticket_id" DataSourceID="SqlDataSource5" EmptyDataText="There are no data records to display.">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                            <asp:BoundField DataField="ticket_id" HeaderText="ticket_id" ReadOnly="True" SortExpression="ticket_id" />
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                            <asp:BoundField DataField="not_creation_date_time" HeaderText="not_creation_date_time" SortExpression="not_creation_date_time" />
                            <asp:BoundField DataField="not_subject" HeaderText="not_subject" SortExpression="not_subject" />
                            <asp:BoundField DataField="not_comment" HeaderText="not_comment" SortExpression="not_comment" />
                            <asp:BoundField DataField="not_text" HeaderText="not_text" SortExpression="not_text" />
                            <asp:CheckBoxField DataField="read_user_not" HeaderText="read_user_not" SortExpression="read_user_not" />
                        </Columns>
                        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#330099" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                        <SortedAscendingCellStyle BackColor="#FEFCEB" />
                        <SortedAscendingHeaderStyle BackColor="#AF0101" />
                        <SortedDescendingCellStyle BackColor="#F6F0C0" />
                        <SortedDescendingHeaderStyle BackColor="#7E0000" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" DeleteCommand="DELETE FROM [tbl_User_Notifications] WHERE [ticket_id] = @ticket_id" InsertCommand="INSERT INTO [tbl_User_Notifications] ([Id], [not_creation_date_time], [not_subject], [not_comment], [not_text], [read_user_not]) VALUES (@Id, @not_creation_date_time, @not_subject, @not_comment, @not_text, @read_user_not)" ProviderName="<%$ ConnectionStrings:DefaultConnection.ProviderName %>" SelectCommand="SELECT [ticket_id], [Id], [not_creation_date_time], [not_subject], [not_comment], [not_text], [read_user_not] FROM [tbl_User_Notifications]" UpdateCommand="UPDATE [tbl_User_Notifications] SET [Id] = @Id, [not_creation_date_time] = @not_creation_date_time, [not_subject] = @not_subject, [not_comment] = @not_comment, [not_text] = @not_text, [read_user_not] = @read_user_not WHERE [ticket_id] = @ticket_id">
                        <DeleteParameters>
                            <asp:Parameter Name="ticket_id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Id" Type="String" />
                            <asp:Parameter DbType="DateTime2" Name="not_creation_date_time" />
                            <asp:Parameter Name="not_subject" Type="String" />
                            <asp:Parameter Name="not_comment" Type="String" />
                            <asp:Parameter Name="not_text" Type="String" />
                            <asp:Parameter Name="read_user_not" Type="Boolean" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Id" Type="String" />
                            <asp:Parameter DbType="DateTime2" Name="not_creation_date_time" />
                            <asp:Parameter Name="not_subject" Type="String" />
                            <asp:Parameter Name="not_comment" Type="String" />
                            <asp:Parameter Name="not_text" Type="String" />
                            <asp:Parameter Name="read_user_not" Type="Boolean" />
                            <asp:Parameter Name="ticket_id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
            <br />
            <br />

        </div>
    </form>




</body>
</html>
