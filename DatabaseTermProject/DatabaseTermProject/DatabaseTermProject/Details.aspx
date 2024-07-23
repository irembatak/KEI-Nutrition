<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="DatabaseTermProject.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />


    <meta charset="UTF-8" />
    <meta name="description" content="Ogani Template" />
    <meta name="keywords" content="Ogani, unica, creative, html" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>Kei Nutrition</title>

    <!-- Google Font -->
    <link href="https://fonts.googleapis.com/css2?family=Cairo:wght@200;300;400;600;900&display=swap" rel="stylesheet" />

    <!-- Css Styles -->
    <link rel="stylesheet" href="css/bootstrap.min.css" type="text/css" />
    <link rel="stylesheet" href="css/font-awesome.min.css" type="text/css" />
    <link rel="stylesheet" href="css/elegant-icons.css" type="text/css" />
    <link rel="stylesheet" href="css/nice-select.css" type="text/css" />
    <link rel="stylesheet" href="css/jquery-ui.min.css" type="text/css" />
    <link rel="stylesheet" href="css/owl.carousel.min.css" type="text/css" />
    <link rel="stylesheet" href="css/slicknav.min.css" type="text/css" />
    <link rel="stylesheet" href="css/style.css" type="text/css" />
</head>
<body>

    <!-- Page Preloder -->
    <div id="preloder">
        <div class="loader"></div>
    </div>

    <!-- Humberger Begin -->
    <div class="humberger__menu__overlay"></div>
    <div class="humberger__menu__wrapper">
        <div class="humberger__menu__logo">
            <a href="#">
                <img src="img/logo.png" alt="" /></a>
        </div>
        <div class="humberger__menu__cart">
            <ul>
                <li><a href="#"><i class="fa fa-heart"></i><span>1</span></a></li>
                <li><a href="#"><i class="fa fa-shopping-bag"></i><span>3</span></a></li>
            </ul>
            <div class="header__cart__price">item: <span>$150.00</span></div>
        </div>
        <div class="humberger__menu__widget">
            <div class="header__top__right__language">
                <img src="img/language.png" alt="" />
                <div>English</div>
                <span class="arrow_carrot-down"></span>
                <ul>
                    <li><a href="#">Spanish</a></li>
                    <li><a href="#">English</a></li>
                </ul>
            </div>
            <div class="header__top__right__auth">
                <a href="#"><i class="fa fa-user"></i>Login</a>
            </div>
        </div>
        <nav class="humberger__menu__nav mobile-menu">
            <ul>
                <li class="active"><a href="./index.aspx">Home</a></li>
                <li><a href="./shop-grid.html">Shop</a></li>
                <li>
                    <a href="#">Pages</a>
                    <ul class="header__menu__dropdown">
                        <li><a href="./shop-details.html">Shop Details</a></li>
                        <li><a href="./shoping-cart.html">Shopping Cart</a></li>
                        <li><a href="./checkout.html">Check Out</a></li>
                        <li><a href="./blog-details.html">Blog Details</a></li>
                    </ul>
                </li>
                <li><a href="./blog.html">Blog</a></li>
                <li><a href="./contact.html">Contact</a></li>
            </ul>
        </nav>
        <div id="mobile-menu-wrap"></div>
        <div class="header__top__right__social">
            <a href="#"><i class="fa fa-facebook"></i></a>
            <a href="#"><i class="fa fa-twitter"></i></a>
            <a href="#"><i class="fa fa-linkedin"></i></a>
            <a href="#"><i class="fa fa-pinterest-p"></i></a>
        </div>
        <div class="humberger__menu__contact">
            <ul>
                <li><i class="fa fa-envelope"></i>hello@colorlib.com</li>
                <li>Free Shipping for all Order of $99</li>
            </ul>
        </div>
    </div>
    <!-- Humberger End -->

    <!-- Header Section Begin -->
    <header class="header">
        <div class="header__top">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6 col-md-6">
                        <div class="header__top__left">
                            <ul>
                             <li><i class="fa fa-envelope"></i>{190706009,190706020,190706006}@st.maltep.edu.tr</li></li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-lg-3">
                    <div class="header__logo">
                        <a href="./index.aspx">
                            <img src="img/keinutrition.png" alt="" /></a>
                    </div>
                </div>


            </div>
            <div class="humberger__open">
                <i class="fa fa-bars"></i>
            </div>
        </div>
    </header>
    <!-- Header Section End -->

        <!-- Hero Section Begin -->
        <section class="hero hero-normal">
            <div class="container">
                <div class="row">
                    <div class="col-lg-3">
                        <div class="hero__categories">
                            <div class="hero__categories__all">
                                <i class="fa fa-bars"></i>
                                <span>Categories</span>
                            </div>
                            <asp:Repeater ID="rpt1" runat="server">
                                <HeaderTemplate>
                                    <ul>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <a href="category.aspx?category=<%#Eval("TypeID") %>"><%#Eval("TypeFood") %></a>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <li><a href="Details.aspx" style="color: green">Add new</a></li>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- Hero Section End -->

        <!-- Breadcrumb Section Begin -->
        <section class="breadcrumb-section set-bg" data-setbg="img/breadcrumb.jpg">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 text-center">
                        <div class="breadcrumb__text">
                            <h2>Nutrition Details</h2>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- Breadcrumb Section End -->
    
        <form id="mainForm" runat="server">
        <!-- Product Details Section Begin -->
        <section class="product-details spad">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6 col-md-6">
                        <div class="product__details__pic">
                            <div class="product__details__pic__item">
                                <img class="product__details__pic__item--large"
                                    src="img/product/details/product-details-1.jpg" alt="" />
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6">
                        <div class="product__details__text">
                            <h3 runat="server" id="headline">Vetgetable’s Package</h3>
                            <h5 runat="server" id="errorSpan" Visible="False" style="color: red;"></h5>

                            <asp:ListBox runat="server" ID="categoryListBox"/>
                            <br/>
                            <ul>
                                <li runat="server" id="nameListEntry">
                                    <b>Name</b>
                                    <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Calorie (kcal)</b>
                                    <asp:TextBox ID="calorieTextbox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Carbohydrate (g)</b>
                                    <asp:TextBox ID="carbohydrateTextbox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Protein (g)</b>
                                    <asp:TextBox ID="proteinTextbox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Oil (g)</b>
                                    <asp:TextBox ID="oilTextbox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Fiber (g)</b>
                                    <asp:TextBox ID="fiberTextbox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Cholesterol (mg)</b>
                                    <asp:TextBox ID="cholesterolTextbox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Sodium (mg)</b>
                                    <asp:TextBox ID="sodiumTextbox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Potassium (mg)</b>
                                    <asp:TextBox ID="potassiumTextbox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Vitamin A (IU)</b>
                                    <asp:TextBox ID="vitaminATextbox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Calcium (mg)</b>
                                    <asp:TextBox ID="calciumTextbox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Vitamin C (mg)</b>
                                    <asp:TextBox ID="vitaminCTextbox" runat="server"></asp:TextBox>
                                </li>
                                <li>
                                    <b>Ferrous (mg)</b>
                                    <asp:TextBox ID="ferrousTextbox" runat="server"></asp:TextBox>
                                </li>
                            </ul>
                            
                            <div style="margin-top: 12px;">
                                <asp:Button runat="server" CssClass="site-btn" ID="updateButton" Text="UPDATE" OnClick="updateButton_Click" />
                                <asp:Button runat="server" CssClass="site-btn" ID="deleteButton" Text="DELETE" OnClick="deleteButton_Click" />
                                <asp:Button runat="server" CssClass="site-btn" ID="createButton" Text="CREATE" OnClick="createButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- Product Details Section End -->
    </form>

    <!-- Footer Section Begin -->
    <footer class="footer spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="footer__about">
                        <div class="footer__about__logo">
                            <a href="./index.aspx">
                                <img src="img/keinutrition.png" alt="" /></a>
                        </div>
                        <ul>
                            <li>Address:Maltepe Istanbul</li>
                            <li>Email: 190706009@st.maltep.edu.tr <br />
                          Email: 190706006@st.maltep.edu.tr <br />
                           Email: 190706020@st.maltep.edu.tr</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </footer>
    <!-- Footer Section End -->
    <!-- Js Plugins -->
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.nice-select.min.js"></script>
    <script src="js/jquery-ui.min.js"></script>
    <script src="js/jquery.slicknav.js"></script>
    <script src="js/mixitup.min.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script src="js/main.js"></script>


</body>
</html>
