
# FileUploader

FileUploader - это приложение для загрузки файлов с использованием ASP.NET Core . Оно поддерживает работу с Swagger для тестирования API.

## Основные возможности

- Загрузка файлов
- Получение списка загруженных файлов
- Поддержка Swagger для документации API

## Требования

- .NET 8.0 SDK
- Docker (для контейнеризации приложения)


## Установка и запуск

### Локальная установка

1. Клонируйте репозиторий:

   ```bash
   git clone https://github.com/DeStiNoVich21/FileUploader.git
   cd FileUploader
   ```

2. Восстановите зависимости и постройте проект:

   ```bash
   dotnet restore
   dotnet build
   ```

3. Запустите проект:

   ```bash
   dotnet run --project MongoDB_Empty_Pattern
   ```

4. Приложение будет доступно по адресу: `http://localhost:5000`

### Использование Docker

1. Убедитесь, что у вас установлен Docker.

2. Постройте Docker-образ:

   ```bash
   docker build -t fileuploader:dev .
   ```

3. Запустите контейнер:

   ```bash
   docker run -d -p 8080:8080 --name fileuploader-container fileuploader:dev
   ```

4. Приложение будет доступно по адресу: `http://localhost:8080`

## Использование Swagger

После запуска приложения вы можете получить доступ к Swagger UI для тестирования API:

- Локально: `http://localhost:5000/swagger/index.html`
- В Docker-контейнере: `http://localhost:8080/swagger/index.html`

## Конфигурация


```

### Профили запуска

Профили запуска находятся в `launchSettings.json` и могут быть использованы для различных окружений. Например, вы можете добавить профиль для работы в Production:

```json
{
  "profiles": {
    "Production": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "http://localhost:8080",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Production"
      }
    }
  }
}
```

## Дополнительная информация

### Логи и отладка

Для просмотра логов контейнера используйте команду:

```bash
docker logs fileuploader-container
```

Для остановки и удаления контейнера используйте команды:

```bash
docker stop fileuploader-container
docker rm fileuploader-container
```

## Вклад

Если вы хотите внести свой вклад в проект, пожалуйста, откройте pull request или создайте issue.



