# Microsoft Commercial Marketplace CSP APIs Demo

This demo project is aimed to demonstrate how to setup and use the [**Partner Center SDK**](https://docs.microsoft.com/en-us/partner-center/develop/get-started). The SDK includes a *managed API* and a *REST API* for partners to use to manage customer, subscription, and order data.

To get access to APIs, your tenant must be a **CSP tenant** and you must be either an *indirect provider* or a *Direct bill partner*.
In order to setup the environment you need a Partner Center Account 

# Projects in this demo
|Project Name|Description|
|:---|:---|
|MarketplaceCSPDemo.Data.PartnerCenter|The main project for the SDK. It contains the context object and the implementation of some sample APIs|
|MarketplaceCSPDemo.Data.Mock|A very simple mockup that must be replaced with the real back office of the CSP partner|
|MarketplaceCSPDemo.Frontend.Web|Demo web app to show how to perform some actions from the CSP perspective (create customer, place an order on behalf of etc..)|
|MarketplaceCSPDemo.Frontend.Customer|Demo web app to show how to implement a custom forefront which allows customer to place an order|

# Prerequisites

First of all you need to setup the API Access in Partner Center (https://docs.microsoft.com/en-us/partner-center/develop/set-up-api-access-in-partner-center)

Once you have access to the APIs, you have to register the application in Azure Active Directory.

Perform the following task to correctly configure the Azure AD application for use with this sample project.

- Sign in to the Azure management portal using credentials that have Global Admin privileges
- Click on the Azure Active Directory icon in the toolbar.
- Click App registrations 
- Register a new application
- Setup Redirect URIs ( You can use http://localhost:[port number] during development).
- Be sure to click the Save button to ensure the changes are saved.

Finally fill the appsettings.Development.json with your client id and secrets

{
  "AzureAd": {

    "Instance": "https://login.microsoftonline.com/",
    "Domain": "[YOUR DOMAIN HERE]" // "e.g. "mydyrectorydomain.onmicrosoft.com",
    "TenantId": "common", 
    "ClientId": "[YOUR CLIENT ID HERE]" // e.g. "14ac325f-e9xc-45c8-8a21-2cdr91cb917b",
    "CallbackPath": "/signin-oidc"
  },
  
  "PartnerCenterOptions": {

    "ClientId": "[YOUR SANDBOX CLIENT ID HERE]" // e.g. "4ab376b5-99d5-4287-af21-e2ab82607e39",
    "ClientSecret": "[YOUR SANDBOX SECRET HERE]" // e.g. "nXXqocVvVByAkWb4edghrzNEFNroxNr810y33woXfae=",
    "AppDomain": "[YOUR SANDBOX DOMAIN HERE]" // e.g. "mysandboxdomain.onmicrosoft.com"
  },

  "DemoCustomerId": "[YOUR DEMO CUSTOMER ID HERE]" // e.g. dfa23r8k-e09c-44ea-82b0-afd7bd547841"

}

# Useful links
- [Partner Center API Scenarios](https://docs.microsoft.com/en-us/rest/api/partner-center-rest/)
- [Partner Center REST API reference](https://docs.microsoft.com/en-us/partner-center/develop/partner-center-rest-api-reference)
- [Partner Center Utilities](https://docs.microsoft.com/en-us/partner-center/develop/utilities)
