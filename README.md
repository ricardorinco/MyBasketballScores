# My Basketball Scores

Este � o reposit�rio do aplicativo MyBasketballScores. 

## Tecnologias

| Tecnologia           | Vers�o      |
| -------------------- | ----------- |
| .Net Core            |         3.1 |
| AngularJS            |         1.7 |
| Microsoft SQL Server | 14.0.3281.6 |


### Projeto: Backend

#### Configura��es Necess�rias

``` sh
	Configurar string de Conex�o
		Projeto: MyBasketballScores.Shared
		Arquivo: Settings.cs
		Data Source={ENDERECO_SERVIDOR}, {PORTA_SERVIDOR};Initial Catalog=MyBasketballScores;User ID={USUARIO};Password={SENHA};

	Migration
		Definir como projeto padr�o: MyBasketballScores.Infra.Data
		Executar: Update-Database
```

#### Resources

Foi criado uma cole��o do para utilizar junto ao Postman, est� cole��o cont�m todos os endpoints com seus respectivos objetos de envio assim como o testes unit�rios de cada endpoint.

> Local do arquivo: "..\MyBasketballScoresMy Basketball Scores.postman_collection.json"


#### Projeto: Frontend

#### Instala��o e Execu��o do App

> Aten��o: Este aplicativo requer que o [Node.js] (https://nodejs.org/).
> Para a correta utiliza��o deste App a aplica��o backend deve estar em execu��o

``` sh
	cd ..\MyBasketballScores\src\MyBasketballScores.WebApp
  
	npm install

	npm run start
```

#### Configura��es (Caso Necess�rias)

``` sh
	Alterar endpoint acesso � Api
		Caminho: "../MyBasketballScores.WebApp\app\configValue.js"
		Arquivo: configValue.js
		baseUrl: "{ENDERECO_ENDPOINT}/api/v1"
```

###### Desenvolvido por Ricardo Rinco