<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <style>
        .layout-container {
            display: flex;
            gap: 10px;
            font-family: Arial;
        }

        .left-menu {
            width: 220px;
            background-color: #f4f4f4;
            padding: 10px;
            border-right: 1px solid #ccc;
        }

        .center-panel {
            flex: 1;
            padding: 10px;
        }

        .right-panel {
            width: 300px;
            background-color: #fafafa;
            padding: 10px;
            border-left: 1px solid #ccc;
        }

        .marquee {
            width: 100%;
            white-space: nowrap;
            overflow: hidden;
            box-sizing: border-box;
            margin-bottom: 10px;
        }

        .menu-tree a {
            display: block;
            padding: 4px 8px;
            color: #333;
            text-decoration: none;
        }

        .menu-tree a:hover {
            background-color: #ddd;
        }

        iframe {
            margin-top: 10px;
        }
    </style>

    <main>
        <div class="layout-container">
            <!-- Left Menu -->
            <div class="left-menu">
                <asp:Menu ID="Menu2" runat="server"
                          Orientation="Vertical"
                          StaticDisplayLevels="1"
                          MaximumDynamicDisplayLevels="2"
                          StaticSubMenuIndent="20px"
                          CssClass="menu-tree"
                          OnMenuItemClick="Menu2_MenuItemClick1">
                    <Items>
                        <asp:MenuItem Text="Mercury" Value="Mercury" />
                        <asp:MenuItem Text="Venus" Value="Venus" />
                        <asp:MenuItem Text="Earth" Value="Earth">
                            <asp:MenuItem Text="Moon" Value="Moon" />
                        </asp:MenuItem>
                        <asp:MenuItem Text="Mars" Value="Mars">
                            <asp:MenuItem Text="Phobos" Value="Phobos" />
                            <asp:MenuItem Text="Deimos" Value="Deimos" />
                        </asp:MenuItem>
                        <asp:MenuItem Text="Jupiter" Value="Jupiter">
                            <asp:MenuItem Text="Io" Value="Io" />
                            <asp:MenuItem Text="Europa" Value="Europa" />
                            <asp:MenuItem Text="Ganymede" Value="Ganymede" />
                            <asp:MenuItem Text="Callisto" Value="Callisto" />
                        </asp:MenuItem>
                        <asp:MenuItem Text="Saturn" Value="Saturn">
                            <asp:MenuItem Text="Titan" Value="Titan" />
                            <asp:MenuItem Text="Enceladus" Value="Enceladus" />
                            <asp:MenuItem Text="Rhea" Value="Rhea" />
                            <asp:MenuItem Text="Mimas" Value="Mimas" />
                            <asp:MenuItem Text="Iapetus" Value="Iapetus" />
                        </asp:MenuItem>
                        <asp:MenuItem Text="Uranus" Value="Uranus">
                            <asp:MenuItem Text="Titania" Value="Titania" />
                            <asp:MenuItem Text="Oberon" Value="Oberon" />
                            <asp:MenuItem Text="Ariel" Value="Ariel" />
                            <asp:MenuItem Text="Umbriel" Value="Umbriel" />
                            <asp:MenuItem Text="Miranda" Value="Miranda" />
                        </asp:MenuItem>
                        <asp:MenuItem Text="Neptune" Value="Neptune">
                            <asp:MenuItem Text="Triton" Value="Triton" />
                            <asp:MenuItem Text="Nereid" Value="Nereid" />
                        </asp:MenuItem>
                        <asp:MenuItem Text="Pluto (Dwarf)" Value="Pluto">
                            <asp:MenuItem Text="Charon" Value="Charon" />
                            <asp:MenuItem Text="Nix" Value="Nix" />
                            <asp:MenuItem Text="Hydra" Value="Hydra" />
                            <asp:MenuItem Text="Kerberos" Value="Kerberos" />
                            <asp:MenuItem Text="Styx" Value="Styx" />
                        </asp:MenuItem>
                    </Items>
                </asp:Menu>
            </div>

            <!-- Center Content -->
            <div class="center-panel">
                <div class="marquee">
                    <marquee direction="left" scrollamount="4">
                       <h1> The structure of the solar system refers to how all the celestial objects—planets, moons, asteroids, and other bodies—are arranged around the Sun, which is at the center...
                    </marquee>
                </div>
                <table style="width: 100%;">
    <tr>
        <td style="width: 50%; vertical-align: top;">
            <asp:TextBox ID="TextBox1" runat="server"
                         TextMode="MultiLine"
                         Width="100%"
                         Height="400px"
                         Style="box-sizing: border-box;" />
        </td>
        <td style="width: 50%; vertical-align: top;">
            <iframe id="webFrame1" runat="server"
                    width="100%"
                    height="400px"
                    style="box-sizing: border-box;"
                    allowfullscreen="true"
                    frameborder="0"></iframe>
        </td>
    </tr>
</table>

                <iframe id="webFrame" runat="server" width="100%" height="400px"></iframe>
                          
            </div>

            <!-- Right Image -->
            <div class="right-panel">
                <asp:Image ID="imgDisplay" runat="server" Width="100%" Height="200px" ImageUrl="https://vip-fargo.com/images/Kerberos.jpg" />
            </div>
        </div>
    </main>
</asp:Content>