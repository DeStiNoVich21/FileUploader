FileUploader
FileUploader - это приложение для загрузки файлов с использованием ASP.NET Core и MongoDB. Оно поддерживает работу с Swagger для тестирования API.

Основные возможности
Загрузка файлов
Получение списка загруженных файлов
Поддержка Swagger для документации API
Требования
.NET 8.0 SDK
Docker (для контейнеризации приложения)
MongoDB (можно использовать локально или через Docker)
Установка и запуск
Локальная установка
Клонируйте репозиторий:

bash
Копировать код
git clone https://github.com/DeStiNoVich21/FileUploader.git
cd FileUploader
Восстановите зависимости и постройте проект:

bash
Копировать код
dotnet restore
dotnet build
Запустите проект:

bash
Копировать код
dotnet run --project MongoDB_Empty_Pattern
Приложение будет доступно по адресу: http://localhost:5000

Использование Docker
Убедитесь, что у вас установлен Docker.

Постройте Docker-образ:

bash
Копировать код
docker build -t fileuploader:dev .
Запустите контейнер:

bash
Копировать код
docker run -d -p 8080:8080 --name fileuploader-container fileuploader:dev
Приложение будет доступно по адресу: http://localhost:8080

Использование Swagger
После запуска приложения вы можете получить доступ к Swagger UI для тестирования API:

Локально: http://localhost:5000/swagger/index.html
В Docker-контейнере: http://localhost:8080/swagger/index.html
