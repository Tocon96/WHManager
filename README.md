# WHManager

Application designed to manage warehouse of a small company.

## Contents

* [Development Environment](#development-environment)
* [Programming language](#programming-language)
* [Functions](#functions)
* [Database](#database)
* [Additional libraries](#additional-libraries)
* [Classes](#classes)

## Development Environment

Visual Studio 2019 v16.11.5

## Programming language

Backend was created using C#, user interface was created with XAML used by WPF.

## Functions

<ul>
  <li>Login</li>
  <li>User management</li>
  <li>Warehouse content management and cataloguing</li>
  <li>Contractor management</li>
  <li>Order and delivery management</li>
  <li>Generating invoices and warehouse documentation</li>
  <li>Generating reports</li>
</ul>

## Database

MSSQL

Current database structure:

<ul>
  <li>_EFMigrationHistory</li>
    <ul>
      <li>MigrationId (Primary key, nvarchar(150), not null),</li>
      <li>ProductVersion (nvarchar(32), not null)</li>
    </ul>
  <li>Clients</li>
    <ul>
      <li>Id (Primary key, int, not null),</li>
      <li>Name (nvarchar(max), not null),</li>
      <li>Nip (float, null),</li>
      <li>PhoneNumber (nvarchar(max), null)</li>
    </ul>
  <li>Config</li>
    <ul>
      <li>Id (Primary key, int, not null),</li>
      <li>Field (nvarchar(max), null),</li>
      <li>Value (nvarchar(max), null)</li>
    </ul>
  <li>ContrahentReports</li>
    <ul>
      <li>Id (Primary key, int, not null),</li>
      <li>ReportOrigin (nvarchar(max), null),</li>
      <li>ContrahentId (int, not null),</li>
      <li>ContrahentName (nvarchar(max), null),</li>
      <li>DateFrom (datetime2(7), null),</li>
      <li>DateTo (datetime2(7), null)</li>
    </ul>
  <li>Deliveries</li>
    <ul>
     <li>Id (Primary key, int, not null),</li>
     <li>ProviderId (Foreign key, int, null),</li>
     <li>DateCreated (datetime2(7), null),</li>
     <li>DateRealized (datetime2(7), null),</li>
     <li>Realized (bit, not null)</li>
    </ul>
 <li>DeliveryElements</li>
    <ul>
     <li>Id (Primary key, int, not null),</li>
     <li>Origin (nvarchar(max), null),</li>
     <li>ProductId (int, not null),</li>
     <li>ProductCount (int, not null),</li>
     <li>DeliveryId (int, not null),</li>
    </ul>
 <li>IncomingDocuments</li>
    <ul>
     <li>Id (Primary key, int, not null),</li>
     <li>ProviderId (Foreign key, int, null),</li>
     <li>DateReceived (datetime2(7), not null)</li>
     <li>DeliveryId (int, not null)</li>
    </ul>
 <li>DocumentData</li>
    <ul>
      <li>Id (Primary key, int, not null),</li>
      <li>DocumentId (int, not null),</li>
      <li>DocumentDate (datetime2(7), not null),</li>
      <li>DocumentType (nvarchar(max), null),</li>
      <li>ContrahentName (nvarchar(max), null),</li>
      <li>ContrahentNip (nvarchar(max), null),</li>
      <li>ContrahentPhoneNumber (nvarchar(max), null),</li>
      <li>ProductNumber (int, not null),</li>
      <li>ProductName (nvarchar(max), null),</li>
      <li>ProductCount (int, not null),</li>
      <li>TaxType (int, not null),</li>
      <li>ProductPrice (decimal(18,2), not null),</li>
      <li>TaxValue (decimal(18,2), not null),</li>
      <li>GrossValue (decimal(18,2), not null),</li>
      <li>NetValue (decimal(18,2), not null),</li>
    </ul>
 <li>Invoices</li>
     <ul>
       <li>Id (Primary key, int, not null),</li>
       <li>DateIssued (datetime2(7), not null),</li</li>></li>
       <li>ClientId (Foreign key, int, not null),</li>
       <li>OrderId (Foreign key, int, not null)</li>
     </ul>
  <li>Items</li>
    <ul>
      <li>Id (Primary key, int, not null),</li>
      <li>ProductId (Foreign key, int, not null),</li>
      <li>DateOfAdmission (datetime2(7), not null),</li>
      <li>DateOfEmission (datetime2(7), null),</li>
      <li>IsInStock (bit, not null),</li>
      <li>IsInOrder (bit, not null),</li>
      <li>OrderId (Foreign key, int, null),</li>
      <li>ProviderId (Foreign key, int, null),</li>
      <li>IncomingDocumentId (Foreign key, int, null),</li>
      <li>OutgoingDocumentId (Foreign key, int, null),</li>
      <li>InvoiceId (Foreign key, int, null),</li>
      <li>DeliveryId (Foreign key, int, not null),</li>
    </ul> 
 <li>ManufacturerReports</li>
    <ul>
      <li>Id (Primary key, int, not null),</li>
      <li>Name (nvarchar(max), null),</li>
      <li>ManufacturerId (Foreign key, int, null),</li>
      <li>DateRealizedFrom (datetime2(7), null),</li>
      <li>DateRealizedTo (datetime2(7), null)</li>
    </ul>
 <li>Manufacturers</li>
    <ul>
      <li>Id (Primary key, int, not null),</li>
      <li>Name (nvarchar(50), not null),</li>
      <li>Nip (float, not null)</li>
    </ul>
 <li>Orders</li>
    <ul>
       <li>Id (Primary key, int, not null),</li>
       <li>Price (decimal(18,2), not null),</li>
       <li>DateOrdered (datetime2(7), not null),</li>
       <li>DateRealized (datetime2(7), null),</li>
       <li>IsRealized (bit, not null),</li>
       <li>ClientId (Foreign key, int, null),</li>
       <li>IncomingDocumentId (Foreign key, int, null)</li>
    </ul>
 <li>OutgoingDocuments</li>
    <ul>
       <li>Id (Primary key, int, not null),</li>
       <li>ContrahentId (Foreign key, int, null),</li>
       <li>DateSent (datetime2(7), not null),</li>
       <li>OrderId (Foreign key, int, not null)</li>
    </ul>
 <li>ProductReports</li>
    <ul>
       <li>Id (Primary key, int, not null),</li>
       <li>Name (nvarchar(max), null),</li>
       <li>ProductId (Foreign key, int, null),</li>
       <li>DateRealizedFrom (datetime2(7), null),</li>
       <li>DateRealizedTo (datetime2(7), null)</li>
    </ul>
<li>Products
    <ul>
       <li>Id (Primary key, int, not null),</li>
       <li>Name (nvarchar(50), not null),</li>
       <li>TypeId (Foreign key, int, not null)</li>
       <li>TaxId (Foreign key, int, not null)</li>
       <li>ManufacturerId (Foreign key, int, not null)</li>
       <li>PriceBuy (decimal(18,2), not null),</li>
       <li>PriceSell (decimal(18,2), not null),</li>
       <li>InStock (bit, not null)</li>
    </ul>
<li>ProductTypes</li>
    <ul>
       <li>Id (Primary key, int, not null),</li>
       <li>Name (nvarchar(30), not null),</li>
    </ul>
<li>Provider</li>
    <ul>
       <li>Id (Primary key, int, not null),</li>
       <li>Name (nvarchar(max), null),</li>
       <li>Nip (float, null),</li>
       <li>PhoneNumber (nvarchar(max), null)</li>
    </ul>
<li>Roles</li>
    <ul>
       <li>Id (Primary key, int, not null),</li>
       <li>Name (nvarchar(max), null)</li>
       <li>Admin (bit, not null)</li>
       <li>Business (bit, not null)</li>
       <li>Contractors (bit, not null)</li>
       <li>Documents (bit, not null)</li>
       <li>Warehouse (bit, not null)</li>
       <li>Report (bit, not null)</li>
    </ul>
<li>Taxes</li>
    <ul>
       <li>Id (Primary key, int, not null),</li>
       <li>Name (nvarchar(50), not null),</li>
       <li>Value (int, not null)</li>
    </ul>
<li>TypeReports</li>
    <ul>
       <li>Id (Primary key, int, not null),</li>
       <li>Name (nvarchar(max), null),</li>
       <li>TypeId (Foreign key, int, null),</li>
       <li>DateRealizedFrom (decimal(18,2), null),</li>
       <li>DateRealizedTo (decimal(18,2), null)</li>
    </ul>
<li>Users</li>
    <ul>
       <li>Id (Primary key, int, not null),</li>
       <li>UserName (nvarchar(max), null),</li>
       <li>PasswordHash (nvarchar(max), null),</li>
       <li>RoleId (Foreign key, int, null)</li>
    </ul>
 </ul>
 
## Additional libraries

  <ul>
    <li>iText - Used for PDF generation</li>
    <li>Entity  Framework - Used for communication between DataAccess layer and database</li>
  </ul>
  
## Classes
    
### DataAccess Layer
  
#### Models
  <ul>
     <li>Client,</li>
     <li>Config,</li>
     <li>ContrahentReports,</li>
     <li>Delivery,</li>
     <li>DeliveryOrderElements,</li>
     <li>DocumentData,</li>
     <li>IncomingDocument,</li>
     <li>Invoice,</li>
     <li>Item,</li>
     <li>Manufacturer,</li>
     <li>ManufacturerReports</li>
     <li>Order,</li>
     <li>OutgoingDocument</li>
     <li>Product,</li>
     <li>ProductReports,</li>
     <li>ProductType,</li>
     <li>Provider,</li>
     <li>Role,</li>
     <li>Tax,</li>
     <li>TypeReports,</li>
     <li>User</li>
  </ul>
  
  #### Repositories
  
  Each of the repository has corresponding interface.
  <ul>
     <li>ClientRepository,</li>
     <li>ConfigRepository,</li>
     <li>ContrahentReportRepository,</li>
     <li>DeliveryOrderElementsRepository,</li>
     <li>DeliveryRepository,</li>
     <li>DocumentDataRepository,</li>
     <li>IncomingDocumentRepository,</li>
     <li>InvoiceRepository</li>
     <li>ItemRepository</li>
     <li>ManufacturerReportsRepository</li>
     <li>ManufacturerRepository,</li>
     <li>OrderRepository,</li>
     <li>OutgoingDocumentRepository,</li>
     <li>ProductReportRepository</li>
     <li>ProductReporistory</li>
     <li>RoleRepository,</li>
     <li>TaxRepository</li>
     <li>TypeReportsRepository</li>
     <li>UserRepository</li>
  </ul>

  #### Data Access classes
  
  <ul>
    <li>WHManagerDBContext</li>
    <li>WHManagerDBContextFactory</li>
  </ul>
  
  ### Business layer
  
  #### Models
  
  <ul>
   <li>Client,</li>
   <li>ClientReportRecord,</li>
   <li>Config,</li>
   <li>ContrahentReportData,</li>
   <li>ContrahentReport,</li>
   <li>Delivery,</li>
   <li>DeliveryOrderTableContent,</li>
   <li>DocumentData,</li>
   <li>IncomingDocument,</li>
   <li>Invoice,</li>
   <li>Item,</li>
   <li>Manufacturer,</li>
   <li>ManufacturerReports,</li>
   <li>Order,</li>
   <li>OutgoingDocument,</li>
   <li>Product,</li>
   <li>ProductItem,</li>
   <li>ProductReports,</li>
   <li>Role,</li>
   <li>Tax,</li>
   <li>TypeReports,</li>
   <li>User</li>
  </ul>

  #### Services
  
  Each service has corresponding interface containing class functions.  
  
  <ul>
     <li>AuthenticationService,</li>
     <li>CommandService,</li>
     <li>DocumentDataService,</li>
     <li>IncomingDocumentService,</li>
     <li>InvoiceService,</li></li>
     <li>OutgoingDocumentService,</li>
     <li>ClientReportRecordService,</li>
     <li>ContrahentReportService,</li>
     <li>ManufacturerReportsService,</li>
     <li>ProductReportsService,</li>
     <li>ProviderReportsRecordService,</li>
     <li>TypeReportsService,</li>
     <li>ClientService,</li>
     <li>ConfigService,</li>
     <li>DeliveryService,
     <li>ItemService,</li>
     <li>ManufacturerService,</li>
     <li>OrderService,</li>
     <li>ProductService,</li>
     <li>ProductTypeService,</li>
     <li>ProviderService,</li>
     <li>RoleService,</li>
     <li>TaxService,</li>
     <li>UserService</li>
  </ul>
  
  ### Presentation layer
  
  Classes within presentation layer consist of partial classes corresponsing to views they are assigned to therefore the list of the classes will be the same as the list of views found below.
  
  ## Views
  <ul>
    <li>CompanyDataView,</li>
    <li>RoleView,</li>
    <li>UserView,</li>
    <li>DeliveryView,</li>
    <li>OrderView,</li>
    <li>ClientView,</li>
    <li>ManufacturerView,</li>
    <li>ProviderView, </li>
    <li>IncomingDocumentView,</li>
    <li>InvoiceView,</li>
    <li>OutgoingDocumentView,</li>
    <li>InitializeCompanyFormView,</li>
    <li>LoginFormView,</li>
    <li>ManageClientReportFormView,</li>
    <li>ManageManufacrurerReportFormView,</li>
    <li>ManageProductReportFormView,</li>
    <li>ManageProviderReportFormView,</li>
    <li>ManageTypeReportFormView,</li>
    <li>ManageClientFormView,</li>
    <li>ManageCompanyDataFormView,</li>
    <li>ManageDeliveryFormView,</li>
    <li>ManageInvoiceFormView,</li>
    <li>ManageManufacturerFoirmView,</li>
    <li>ManageOrderFormView,</li>
    <li>ManageProductFormView,</li>
    <li>ManageProductTypeFormView,</li>
    <li>ManageProviderFormView,</li>
    <li>ManageRoleFormView,</li>
    <li>ManageTaxFormView,</li>
    <li>ManageUserFormView,</li>
    <li>ContrahentReportDisplayView,</li>
    <li>ManufacturerReportDisplayView,</li>
    <li>ProductReportDisplayView, </li>
    <li>ProductTypeReportDisplayView,</li>
    <li>ProviderReportDisplayView,</li>
    <li>ClientReportView,</li>
    <li>ManufacturerReportView,</li>
    <li>ProductReportView,</li>
    <li>ProductTypeReportView,</li>
    <li>ProviderReportView,</li>
    <li>DeliveryItemsView,</li>
    <li>EmittedItemsView,</li>
    <li>ItemView,</li>
    <li>OrdersItemsView,</li>
    <li>ProductTypeView,</li>
    <li>ProductView,</li>
    <li>TaxView</li>
  </ul>
  
  #### Example views:
  
  Login view:
  <br />
  ![image](https://user-images.githubusercontent.com/61763052/234989005-ee53e836-4ad3-4319-97e1-49c66cfdbb44.png)

  Product view:
  <br />
  ![image](https://user-images.githubusercontent.com/61763052/234989098-9bec9b52-5583-44d4-9301-4cb57db45088.png)
  
  Create new product view:
  <br />
  ![image](https://user-images.githubusercontent.com/61763052/234989140-35258be4-4f63-451f-9b6a-84bf7b59cbb3.png)
  
  Client report view:
  <br />
  ![image](https://user-images.githubusercontent.com/61763052/234989185-196ce227-6e98-47f5-b582-81372f97b225.png)



  
