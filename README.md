# RentCarProject--Backend

Rent Car Project

SOLID prensiplerine uygun bir şekilde yaptığım bu projede soyutlamanın dibine vurdum.Autofac in AOP altyapısını kullanarak Cross Cutting Concerns leri etkili bir şekilde entegre ettim.Yine Autofac in IOC altyapısını kullanarak projedeki sınıfların bağımlılıklarını minimize etmeye çalıştım.Businesstaki iş kodalrını if içinde if yapmak yerine iş motoru yazdım ve iş kurallarını bu motorda yönettim.Herhangi bir fonksiyonun işlem durumunu veya mesaj gösterilmek isteniyosa bilgilendirme mesajını döndüren türüne göre data döndüren veya döndürmeyen fonksiyonlar için core katmanına result yapılanmasını ekledim.Resim yüklendiği zaman resim yolunu veritabanına resmin kendisinide yeni bir gui ile projenin içine dosyaladım.Validation kısmında Fluent Validation paketini kullandım.DataAccess kısmında Reposştory Design Pattern den yararlanarak CRUD işlemlerini tek çatı altında topladım.Asp.Net Core WebAPI kullanarak projeyi günümüz teknolojilerine uygun ve farklı platformlardan erişilebilecek duruma getirdim.                               

Cross Cutting Concerns
--Cache
--Transaction
--Performance
--Validation
--Authorization
--Log(eklenecek)

