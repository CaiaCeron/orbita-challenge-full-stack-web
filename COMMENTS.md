# Notas do Desenvolvedor

## Decisão da arquitetura utilizada

Optei por utilizar uma arquitetura monolítica para desenvolver a api pois o sistema está inteiro em um bloco, isso torna desenvolvimento mais ágil e é possível subir o projeto de forma rápida e simplificada, permitindo ser executado por uma equipe menor ou com menos qualificação.

O banco de dados selecionado para desenvolver a aplicação foi o postgreSQL.
 
Utilizei a arquitetura MVC para realizar a comunicação entre as camadas, pois ela por fornecer uma boa segurança a camada de persistência além de ser de rápida implementação.
 
Para realizar a comunicação entre cliente e servidor, utilizei o axios como cliente http.


## Lista de bibliotecas de terceiros utilizadas
* [VueCLI;](https://cli.vuejs.org/)
* [VueRouter;](https://router.vuejs.org/)
* [Vuetify;](https://vuetifyjs.com/en/)
* [VeeValidate.](https://vee-validate.logaretm.com/v4/)


## O que você melhoraria se tivesse mais tempo

Com mais tempo para desenvolver o projeto, seria possível melhorar alguns pontos importantes como: validação dos dados tanto no backend como no frontend, e melhorar a experiência de usuário modificando a disposição dos elementos na tela.