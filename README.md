# My Basketball Scores

Este é o repositório do aplicativo MyBasketballScores. 

## Tecnologias

| Tecnologia           | Versão      |
| -------------------- | ----------- |
| .Net Core            |         3.1 |
| AngularJS            |         1.7 |
| Microsoft SQL Server | 14.0.3281.6 |


### Projeto: Backend

#### Configurações Necessárias

``` sh
	Configurar string de Conexão
		Projeto: MyBasketballScores.Shared
		Arquivo: Settings.cs
		Data Source={ENDERECO_SERVIDOR}, {PORTA_SERVIDOR};Initial Catalog=MyBasketballScores;User ID={USUARIO};Password={SENHA};

	Migration
		Definir como projeto padrão: MyBasketballScores.Infra.Data
		Executar: Update-Database
```

#### Resources

Foi criado uma coleção do para utilizar junto ao Postman, está coleção contém todos os endpoints com seus respectivos objetos de envio assim como o testes unitários de cada endpoint.

> Local do arquivo: "..\MyBasketballScoresMy Basketball Scores.postman_collection.json"


#### Projeto: Frontend

#### Instalação e Execução do App

> Atenção: Este aplicativo requer que o [Node.js] (https://nodejs.org/).
> Para a correta utilização deste App a aplicação backend deve estar em execução

``` sh
	cd ..\MyBasketballScores\src\MyBasketballScores.WebApp
  
	npm install

	npm run start
```

#### Configurações (Caso Necessárias)

``` sh
	Alterar endpoint acesso à Api
		Caminho: "../MyBasketballScores.WebApp\app\configValue.js"
		Arquivo: configValue.js
		baseUrl: "{ENDERECO_ENDPOINT}/api/v1"
```

###### Desenvolvido por Ricardo Rinco