EntityFileGenerator Tool
Bu araç, .NET projelerinde Entity, Interface ve EfEntity dosyalarını otomatik olarak oluşturmanıza yardımcı olur. Özellikle Entity Framework ve Repository Pattern kullanan projelerde, her bir entity sınıfı için gerekli temel dosyaları hızlıca oluşturmak için kullanılır.

Özellikler
Entity dosyasının oluşturulması: Veritabanı tablosuna karşılık gelen entity sınıfını oluşturur.

Interface Layer: Her entity için gerekli olan DAL (Data Access Layer) arayüzünü oluşturur.

EfEntity Layer: Entity Framework ile ilgili implementasyonu içeren sınıfı oluşturur.

Dizin Bazlı İşlem: Belirli bir dizindeki tüm dosyalar üzerinden işlem yaparak ilgili dosyaların hızlıca oluşturulmasını sağlar.

Kullanım
Projeye dahil etme:

Bu araç, .NET projenize dahil edilerek kullanılabilir. EntityLayer, InterfaceLayer, ve EfLayer gibi fonksiyonlar üzerinden işlemlerinizi yönetebilirsiniz.

Dosya Oluşturma:

Directory.GetFiles() metodu ile belirttiğiniz dizindeki dosyaları okur ve her dosya için ilgili Entity, Interface, ve EfEntity dosyalarını oluşturur.

Dosyalar varsayılan olarak Entities/Concrete, DataAccess/Abstract ve DataAccess/Concrete/EntityFramework dizinlerine kaydedilir.

Kod Kalıbı:

Dosya içeriği, önceden belirlenmiş bir formatta (entity, interface ve ef repository) otomatik olarak oluşturulur ve yazılır.

Özelleştirme:

Dosya şablonları, string formatları ile özelleştirilebilir ve ihtiyaçlarınıza göre genişletilebilir.

Kullanıcı Kılavuzu
CreateFiles fonksiyonu ile mevcut dizindeki dosyaları okuyarak her biri için ilgili dosyaları oluşturabilirsiniz.

EntityLayer, InterfaceLayer, EfLayer fonksiyonlarını kullanarak her dosya tipi için ayrı işlemler gerçekleştirebilirsiniz.

Bu tool, dosyaların aynı dizinde yeniden işlenmesini engellemek için kontroller içerir.
