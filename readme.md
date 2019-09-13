# Attachment Core

Lightweight Attachment Module For ASP.NET Core 
## Getting Started

### install

```bash
Install-Package AttachmentCore -Version 0.0.9-alpha
```

### Backend-End Configuration

```c#
public void ConfigureServices(IServiceCollection services)
 {
    ...
    services.AddAttachment();
    services.AddMvc();
    ...
 }
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
 {
    ...
    app.UseAttachment();
    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");
    });
    ...
 }
```

### Front-End Configuration

you can use it in your html without any framework:

```bash
<html lang="en">
<head>
  <script src="https://unpkg.com/attachment-core/dist/attachmentsystem.js"></script>

</head>
<body>
  <attachment-input entity-name="entity name" field-name="field name" entity-id="entity id"></attachment-input>
</body>
</html>
```

for offline use you must download package by following command:
```bash
npm pack attachment-core
```

 then extract it in your wwwroot folder and reference to it. to using in Angular2+,React and Vue use [this documentation](https://github.com/attachmentcore/attachment-core/tree/master/AttachmentCore.Component)  

### Customization

#### Set connection string of database
default  connection string is set to :
```
Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=attachmentDB;Integrated Security=True;Pooling=False
```
To change it to your connection string change `AddAttachment()` as follows:
```csharp
services.AddAttachment("your connection string");
```
#### Authorization

to control accessibility of users you must implemet `IAttachmentAuthorization` interface as follows:
```csharp
public class AttachmentAuthorization : IAttachmentAuthorization
{
    public bool Create(AttachmentKeyModel model)
    {
        //check accessibility by your own logic 
    }
    public bool Details(AttachmentItemKeyModel model)
    {
        //check accessibility by your own logic
    }
    public bool Download(AttachmentItemKeyModel model)
    {
        //check accessibility by your own logic
    }
    public bool Read(AttachmentKeyModel model)
    {
        //check accessibility by your own logic
    }
    public bool Remove(DeleteAttachmentItemModel model)
    {
        //check accessibility by your own logic
    }
    public bool Upload(UploadAttachmentItemModel model)
    {
        //check accessibility by your own logic
    }
}
```

Then introduce this implementation to AttachmentCore by change `AddAttachment()` method as follows:

```csharp
services.AddAttachment()
        .UseAuthorizationHandler<AttachmentAuthorization>();
```