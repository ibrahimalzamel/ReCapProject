# ReCapProject - Araç Kiralama Sistemi

Bu repo **Yazılım Geliştirici Yetiştirme Kampı**'nda yapılan çalışmaları kapsayan **Araç Kiralama Projesi**'ni içerir.
## :pushpin:Getting Started
N-Katmanlı mimari yapısı ile hazırlanan, EntityFramework kullanılarak CRUD işlemlerinin yapıldığı, Wpf arayüzü ile çalışan, Araç Kiralama iş yerlerine yönelik örnek bir proje.
## :books:Layers  
## Entities Layer
Veritabanı nesneleri için oluşturulmuş **Entities Katmanı**'nda **Abstract** ve **Concrete** olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.  
<br>:file_folder:`Abstract`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: ~~IEntity.cs~~ (Ortak Kod Olduğu İçin Core Katmanına Aktarıldı.)
<br> <br> :file_folder:`Concrete`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [Brand.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Entities/Concrete/Brand.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [Car.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Entities/Concrete/Car.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [Color.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Entities/Concrete/Color.cs)  
<br>
##  Business Layer
Sunum katmanından gelen bilgileri gerekli koşullara göre işlemek veya denetlemek için oluşturulan **Business Katmanı**'nda **Abstract**,**Concrete**,**Utilities** ve **ValidationRules** olmak üzere dört adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.Utilities ve ValidationRules klasörlerinde validation işlemlerinin gerçekleştiği classlar mevcuttur.  
<br>:file_folder:`Abstract`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [ICarService.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Business/Abstract/ICarService.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IColorService.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Business/Abstract/IColorService.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IBrandService.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Business/Abstract/IBrandService.cs)  
<br> <br> :file_folder:`Concrete`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [CarManager.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Business/Concrete/CarManager.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [ColorManager.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Business/Concrete/ColorManager.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [BrandManager.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Business/Concrete/BrandManager.cs)    

<br> :file_folder:`ValidationRules`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:file_folder: `FluentValidation`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [CarValidator.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Business/ValidationRules/FluentValidation/CarValidator.cs)   
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [ColorValidator.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Business/ValidationRules/FluentValidation/ColorValidator.cs)   
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [BrandValidator.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Business/ValidationRules/FluentValidation/BrandValidator.cs)   
<br>
##  Data Access Layer
Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulan **Data Access Katmanı**'nda **Abstract** ve **Concrete** olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.  
<br>:file_folder:`Abstract`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IBrandDal.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/DataAccess/Abstract/IBrandDal.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [ICarDal.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/DataAccess/Abstract/ICarDal.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IColorDal.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/DataAccess/Abstract/IColorDal.cs)  
<br> <br> :file_folder:`Concrete`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:file_folder: `EntityFramework`    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [EfBrandDal.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfBrandDal.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [EfCarDal.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfCarDal.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [EfColorDal.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/DataAccess/Concrete/EntityFramework/EfColorDal.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [NorthwindContext.cs](https://github.com/ibrahimalzamel/FinalProject/blob/master/DataAccess/Concrete/EntityFramework/NorthwindContext.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:file_folder: `InMemory`    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: ~~InMemoryCarDal.cs~~  
<br>



##  Core Layer
Bir framework katmanı olan **Core Katmanı**'nda **DataAccess**, **Entities**, **Utilities** olmak üzere 3 adet klasör bulunmaktadır.DataAccess klasörü DataAccess Katmanı ile ilgili nesneleri, Entities klasörü Entities katmanı ile ilgili nesneleri tutmak için oluşturulmuştur. Core katmanının .Net Core ile hiçbir bağlantısı yoktur.Oluşturulan core katmanında ortak kodlar tutulur. Core katmanı ile, kurumsal bir yapıda, alt yapı ekibi ilgilenir.  
> **⚠ DİKKAT: .**  
> Core Katmanı, diğer katmanları referans almaz.
<br> <br> :file_folder:`DataAccess`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IEntityRepository.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/DataAccess/IEntityRepository.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:file_folder: `EntityFramework`    
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [EfEntityRepositoryBase.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/DataAccess/EntityFramework/EfEntityRepositoryBase.cs)  
<br> :file_folder:`Entities`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IEntity.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/Entities/IEntity.cs)   
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IDto.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/Entities/IDto.cs)  

:file_folder:`Utilities`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:file_folder: `Results`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:file_folder: `Abstract`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IResult.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/Utilities/Results/IResult.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [IDataResult.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/Utilities/DataResults/IDataResult.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:file_folder: `Concrete`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [DataResult.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/Utilities/DataResults/DataResult.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [ErrorDataResult.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/Utilities/DataResults/ErrorDataResult.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [ErrorResult.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/Utilities/Results/ErrorResult.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [Result.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/Utilities/Results/Result.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [SuccessDataResult.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/Utilities/DataResults/SuccessDataResult.cs)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [SuccessResult.cs](https://github.com/ibrahimalzamel/ReCapProject/blob/master/Core/Utilities/Results/SuccessResult.cs)  

## Veritabanı Oluşturma (localdb)
Araba Kiralama Projemiz localdb ile çalışmaktadır. **LocalDb**'de veritabanı oluşturmak için **Visual Studio 2019** için *View > SQL Server Object Explorer* menü yolunu takip edebilirsiniz.Pencere açıldıktan sonra *SQL Server > 
(localdb)MSSQLLocalDB* altındaki **Databases** klasörüne sağ tıklayıp Add **New Database** seçeneğini ile veritabanınızı oluşturabilirsiniz. 
Veritabanı oluşturulduktan sonra **New Query** seçerek aşağıda bulunan Sql File ile veritabanınızda olması gereken tabloları oluşturabilirsiniz.  
<br>
:file_folder:`Sql File`  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [SqlQuery.sql](https://github.com/ibrahimalzamel/ReCapProject/blob/master/SqlQuery.sql)  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:page_facing_up: [SQLQuery2.sql](https://github.com/ibrahimalzamel/ReCapProject/blob/master/SQLQuery2.sql)  
<br>
<br><br>


```
EntityFrameworkCore.SqlServer 3.1.11
FluentValidation 7.3.3
```
## :pencil2:Authors
* **İbrahim ALZAMEL** - [ibrahimalzamel](https://github.com/ibrahimalzamel)
