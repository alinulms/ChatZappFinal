<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBoardControl.ascx.cs" Inherits="Website.Presentation.Controls.MessageBoardControl" %>
<%@ Import Namespace="Website.Model" %>

<div class="box-wide panel-box discussions-list-viewport">
    <asp:Repeater runat="server" ID="Discussions" DataSource="<%#GetMessageBoardDiscussions() %>">
        <HeaderTemplate>
            <ul class="list-group">
        </HeaderTemplate>
        <ItemTemplate>
            <li id="conversation_<%#(((Message)Container.DataItem).GroupId) %>" class="list-group-item">
                <span class="badge"><%# GetMessagesInDiscussion(((Message)Container.DataItem).GroupId) %></span>
                <asp:LinkButton runat="server" OnClick="ShowDiscussion" CommandArgument="<%#((Message)Container.DataItem).GroupId %>">
                        <p>
                          <strong><%#((Message)Container.DataItem).Author %> :</strong>
                          <%#((Message)Container.DataItem).Text %>
                        </p>
                </asp:LinkButton>
                <%#((Message)Container.DataItem).SendTime.ToString("dd-MM-yyyy  HH:mm") %>
                <em>
                    <%#GetElapsedTime((Message)Container.DataItem) %>
                </em>
                <em>
                  <%#Website.Resources.MessageBoard.Nearby %>  <%#((Message)Container.DataItem).NearbyPlace %>
                </em>            
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</div>