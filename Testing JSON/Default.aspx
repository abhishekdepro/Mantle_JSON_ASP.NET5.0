<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Testing_JSON._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>Mantle</h1>
        <p class="lead">An opensource framework for predicting weather data.<br /><asp:button id="ButtonFb" runat="server" OnClick="ButtonFb_Click" class="btn btn-primary" type="button" Text="Get my City!"></asp:button>
          </p>
        
    </div>

    <div class="row">
        
        <br />
        <div class="col-md-12">
            
            <br />
            
            <div class="panel panel-primary">
              <div class="panel-heading">
                <h3 class="panel-title">Weather Infromation Panel</h3>
              </div>
              <div class="panel-body">
                <div class="col-md-4">
            <h2>Temperature</h2>
            
            <div id="input-collection" class="input-group input-group-lg">
          
              <input id= "urlinputbox" runat="server" type="text" class="form-control" name = "url" placeholder="Name of city">
          <span class="input-group-btn">
              <asp:button id="submiturlbtn" runat="server" OnClick="submiturlbtn_clicked" class="btn btn-primary" type="button" Text="° Celcius"></asp:button>
          </span>
                
           </div>
            
        
        </div>

        <div class="col-md-4">
            <h2>Weather Condition</h2>
            
            <div id="input-collection" class="input-group input-group-lg">
          
              <input id= "conditionText" runat="server" type="text" class="form-control" name = "url" placeholder="Name of city">
          <span class="input-group-btn">
              <asp:button id="Button2" runat="server" OnClick="submiturlbtn_clicked" class="btn btn-primary" type="button" Text="Condition"></asp:button>
          </span>
                
           </div>
            
        
        </div>
        <div class="col-md-4">
            <h2>Rainfall</h2>
            
            <div id="input-collection" class="input-group input-group-lg">
          
              <input id= "Text2" runat="server" type="text" class="form-control" name = "url" placeholder="Name of city" disabled="disabled">
          <span class="input-group-btn">
              <asp:button id="btnhumi" runat="server" OnClick="submiturlbtn_clicked" class="btn btn-primary" type="button" Text="cm Rainfall"></asp:button>
          </span>
                
           </div>
            
        
        </div>
                   <div class="col-md-4">
            <h2>Humidity</h2>
            
            <div id="input-collection" class="input-group input-group-lg">
          
              <input id= "humidityText" runat="server" type="text" class="form-control" name = "url" placeholder="Name of city" >
          <span class="input-group-btn">
              <asp:button id="btnhumid" runat="server" OnClick="submiturlbtn_clicked" class="btn btn-primary" type="button" Text="% (percentage)"></asp:button>
          </span>
                
           </div>
            
        
        </div>
              </div>
            </div>
            
        
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-6">
            <div class="alert alert-info">
                
                <asp:label id="weathercondition" runat="server" Text="Weather Condition:"></asp:label>
             
                          </div>
                
        </div>
    
    
        <div class="col-md-6">
            <div class="alert alert-danger">
                
                <asp:label id="error" runat="server" Text="Error Message:"></asp:label>
             
                          </div>
           
           
                
        </div>
    </div>
</asp:Content>
