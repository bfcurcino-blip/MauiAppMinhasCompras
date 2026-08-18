# MauiAppMinhasCompras

Aplicativo desenvolvido em .NET MAUI utilizando o Visual Studio e banco de dados SQLite.

O projeto foi desenvolvido como parte da atividade da Agenda 02, da disciplina de Desenvolvimento de Sistemas III, do Módulo 3 do curso de Desenvolvimento de Sistemas, com o objetivo de colocar em prática o conteúdo estudado na disciplina.

## Funcionalidades

O aplicativo permite:
- Cadastrar novos produtos, informando descrição, quantidade e preço;
- Armazenar os dados utilizando SQLite;
- Visualizar os produtos cadastrados em uma lista;
- Selecionar um produto já cadastrado;
- Editar as informações do produto;
- Salvar as alterações realizadas e atualizar a listagem.

## Atualização do projeto

Após a primeira versão, foi implementada a funcionalidade de edição de produtos. Ao selecionar um item na tela de listagem, o aplicativo abre a tela Editar Produto, permitindo alterar a descrição, a quantidade e o preço. Após salvar, os dados são atualizados no banco SQLite e exibidos novamente na listagem.

## Tecnologias utilizadas

- .NET MAUI
- C#
- XAML
- SQLite
- Visual Studio

## Estrutura do projeto

O projeto possui uma tela para cadastrar novos produtos, informando descrição, quantidade e preço, uma tela para visualizar os produtos cadastrados e uma tela para editar as informações dos produtos já existentes.

Também foi utilizada uma classe para representar os produtos e uma classe responsável pela comunicação com o banco de dados SQLite.

## Testes

Foram realizados testes de cadastro, listagem e edição para verificar o funcionamento do aplicativo. Durante os testes, os produtos foram cadastrados e exibidos corretamente na tela de listagem. Também foi realizada a alteração da quantidade de um produto já cadastrado, confirmando que as informações foram atualizadas corretamente no banco de dados e exibidas novamente na listagem.

## Imagens do projeto

### Aplicativo em funcionamento

#### Cadastro de produto

Tela utilizada para cadastrar um novo produto, informando descrição, quantidade e preço.

![Cadastro de produto](Captura%20de%20tela%202026-08-18%20133718.png)

#### Edição de produto

Tela utilizada para alterar as informações de um produto já cadastrado.

![Edição de produto](Captura%20de%20tela%202026-08-18%20133857.png)

#### Produto atualizado

Após a edição, o produto é atualizado e exibido novamente na tela de listagem.

![Produto atualizado](Captura%20de%20tela%202026-08-18%20133944.png)

## Autora

Bianca da Silva Fernandes Curcino
