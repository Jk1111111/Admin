<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/Share2.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="UserPages_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../UserCss/share2.css" rel="stylesheet" />
    <link href="../UserCss/index.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
    <div class="slideshow-container">
        <div class="slideshow-container">
            <div class="mySlides fade">
                <div class="numbertext">1</div>
                <img src="../Image/slide1.jpg" style="width:100%">
                <div class="text">Punjab Institute Of Medical College</div>
            </div>
        </div>
        <div class="slideshow-container">
            <div class="mySlides fade">
                <div class="numbertext">2</div>
                <img src="../Image/slide2.jpg" style="width:100%">
                <div class="text">Prasad Hospital</div>
            </div>
        </div>
        <div class="slideshow-container">
            <div class="mySlides fade">
                <div class="numbertext">3</div>
                <img src="../Image/slide3.jpg" style="width:100%">
                <div class="text">CMC Hospital</div>
            </div>
        </div>
    </div>
    <br/>
    <div style="text-align:center">
        <span class="dot"></span> 
        <span class="dot"></span> 
        <span class="dot"></span> 
        </div>
    <script>
    var slideIndex = 0;
    showSlides();
        function showSlides() {

            var i;
            var slides = document.getElementsByClassName("mySlides");
            var dots = document.getElementsByClassName("dot");
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slideIndex++;
            if (slideIndex > slides.length) { slideIndex = 1 }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            slides[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += " active";
            setTimeout(showSlides, 2000); // Change image every 2 seconds
        }
    </script>
    <h1 style="font-size:40px;font-family:Arial;text-align:center;margin:0">Welcome to HospiceFriendly</h1>
    <h1 style="font-size:22px;font-family:Arial;text-align:center;color:#8f4242;word-spacing:8px;margin:0;font-weight:100">An Application to Assist Doctors</h1>
    <p style="margin:55px;text-align:center;color:#000000;font-weight:500">
        HospiceFriendly is an Solution for Doctor to keep track of his patient's conditions. Book an appointment
        with Doctor also an Platform for Patients to take care of themselves
    </p>
    <div class="box_div">
        <div class="box1">
            <img src="../Image/about.jpg" style="height:220px;width:510px;margin-left:75px;margin-top:20px;"/>
        </div>
        <div class="box1">
            <h2 style="color:#2a75b5"> We Care About Your Health</h2>
            <p style="color:#808080;word-spacing:5px;font-family:'Times New Roman';width:500px;font-size:18px">
                This is an application to help doctor tackle the problems they face Idea is to develop an application
                for doctors working in Hospitals so that they can get updated information
                of patients under their care.They can get information of patients who need immediate acknowledgement.
            </p>
            <asp:Button ID="Button1" runat="server" Text="Read More" CssClass="btn"/>
        </div>
    </div>
    <div class="box_div1">
        <h1 style="font-size:40px;font-family:Arial;text-align:center;margin:0">Welcome to HospiceFriendly</h1>
    </div>
</div>
</asp:Content>

