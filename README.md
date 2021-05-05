# Overview

O [LiteDb](https://www.litedb.org/) é um banco de dados NoSql desenvolvido e mantido pelos brasileiros [Mauricio David](https://github.com/mbdavid),[Cassiano Sombrio](https://github.com/kcsombrio) e [Leonardo Nascimento](https://github.com/lbnascimento).

# Features

 - Não necessita de um servidor de documentos NoSql
 - Possui uma API simples muito semelhante ao do MongoDb
 - Suporte para Portable UWP/PCL
 - Recuperação de dados após falha de gravação
 - Criptografia de arquivo de dados usando criptografia DES (AES)
 - Transações ACID (atomicidade, consistência, isolamento e durabilidade)
 - Recuperação de dados após falha de gravação (journal mode)
 - Mapeie suas classes POCO para o BsonDocument usando atributos ou usando Fluent Mapper API
 - Armazenar arquivos e dados de fluxo (como GridFS no MongoDB)
 - Armazenamento de arquivos de dados simples (como SQLite)
 - Indexação de campos dos documentos para pesquisa rápida (até 16 índices por coleção)
 - Suporte a consultas LINQ
 - Shell de comando

Fonte: [Blog Raphael Cardoso](https://raphaelcardoso.com.br/conhecendo-e-usando-o-litedb/) e [LiteDB](https://www.litedb.org/)

# Setup

Baixe e instale o [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)

# Criando uma API integrada com o LiteDB

Para criar um projeto Web API, basta digitar o seguinte comando:
```
dotnet new webapi
```

Após a criação do projeto, iremos adicionar o seguinte pacote:
```
dotnet add package LiteDB --version 5.0.10
```

Agora, vamos adicionar as seguintes classes para que o nosso CRUD funcione:

![Estrutura do Projeto](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/w07ip9pl1m1tvmjecgky.png)

Para não deixar o artigo muito longo, aqui está os links das classes criadas:
Pasta “Common”:
[Config.cs](https://github.com/joao2391/LiteDB_API_Example/blob/master/Common/Configs.cs)
[Constants.cs](https://github.com/joao2391/LiteDB_API_Example/blob/master/Common/Constants.cs)
[ILiteDBContext.cs](https://github.com/joao2391/LiteDB_API_Example/blob/master/Common/ILiteDBContext.cs)
[LiteDBContext.cs](https://github.com/joao2391/LiteDB_API_Example/blob/master/Common/LiteDBContext.cs)
[LiteDBExtensions.cs](https://github.com/joao2391/LiteDB_API_Example/blob/master/Common/LiteDBExtensions.cs)
Pasta “Controller”:
[CustomerController.cs](https://github.com/joao2391/LiteDB_API_Example/blob/master/Controllers/CustomerController.cs)
Pasta “Models”:
[Customer.cs](https://github.com/joao2391/LiteDB_API_Example/blob/master/Models/Customer.cs)
Pasta “Services”:
[ILiteDBServices.cs](https://github.com/joao2391/LiteDB_API_Example/blob/master/Services/ILiteDBServices.cs)
[LiteDBService.cs](https://github.com/joao2391/LiteDB_API_Example/blob/master/Services/LiteDBServices.cs)

Repare que a classe “LiteDBExtensions.cs”, está sendo usada para facilitar a manutenção e legibilidade do código.

![Classe LiteDBExtensions](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/tykcv5ws6fgmcqewjn3x.png)

Esses dois métodos de extensão criados, são utilizandos dentro da classe “Startup.cs”.

![Método ConfigureServices da classe Startup](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/fqmmhte51ud0y3ysns30.png)

# Testando nossos endpoints

Primeiro, vamos iniciar a nossa API através do comando:
```
dotnet run
```

Agora, vamos fazer um requisição POST para inserir uma informação em nosso banco de dados:

![Método POST](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/9rqwt79fenolhl7d3gsf.png)

![Postman POST](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/hfr6xenn2cwy6hhyyawa.png)

![Postman retorno](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/qcdcghmibca7s7o8gj9k.png)

Após a requisição POST, vamos verificar, através da requisição GET se a informação foi, realmente, inserida

![Método GET](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/2goieiw6kx7la0tkibcm.png)

![Postman GET](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/llyz4t4llrruink2dkod.png)

![Postman retorno](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/64k84rac6qcw1kq8nfe2.png)

Repare que este método retorna todas as informações, pois não foi especificado um “Id” na hora da requisição.
Para retornar um cadastro específico, bastamos informar o “Id”

![Método GET/ID](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/692x1cj4z631ehcqviv4.png)

![Postman GET/ID](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/g2j6ou99t4p70mz80ycc.png)

![Postman retorno](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/dgs4ula7eyy5wacin5f2.png)

Pronto! Temos nosso primeiro cadastro realizado. Se quisermos alterá-lo ou excluí-lo, temos um endpoint para cada função.

![Método PUT](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/40a9j4lqb2wo3802n5ku.png)

![Postman PUT](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/s59whlgbbzg28j3dgg6s.png)

![Postman Retorno](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/1wlnb6pm988p33g2pw26.png)

![Método DELETE](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/6y9jxtyx9m7qwfezrd14.png)

![Postman DELETE](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/cwt0vgqqh30lxtw4sh4n.png)

![Postman retorno](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/vhbbv83yrm6c2cmm9ck4.png)

Mas então, onde as informações estão sendo salvas? 
As informações são salvas em um arquivo “.db”, localizado dentro do seu projeto

![arquivos “nameofDb.db”](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/betdkb3160dzhnripvdy.png)

As classes de "services" e "context", fazem o trabalho de buscar e inserir as informações dentro do arquivo.

O nome do arquivo é definido da seguinte maneira:

![caminho para o arquivos](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/2nez1hj8bp8nvvr4h3ij.png)

# Conclusão
Como podemos perceber, o LiteDB pode ser usado em diversas situações e projetos. Cabe a você decidir onde e quando usá-lo.

Espero que vocês tenham gostado. Dúvidas, sugestões ou críticas deixem nas Issues.

Um grande abraço!
