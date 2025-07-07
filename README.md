# Gerenciamento de Funcionários

Este é um projeto simples de gerenciamento de funcionários desenvolvido em C#. Ele funciona como um aplicativo de console interativo, permitindo realizar operações básicas para administrar informações de colaboradores.

## Funcionalidades

O programa oferece um menu intuitivo para:

* **Adicionar Funcionários:** Cadastrar novos colaboradores com nome, salário e cargo. Inclui validação para garantir que os dados de entrada sejam sempre válidos.
* **Listar Funcionários:** Visualizar a lista completa de todos os funcionários cadastrados.
* **Filtrar por Cargo:** Exibir apenas os funcionários que pertencem a um cargo específico.
* **Aumentar Salário:** Aplicar um aumento percentual no salário de um funcionário específico, identificado pelo nome.
* **Calcular Média Salarial por Cargo:** Obter a média dos salários dos funcionários de um determinado cargo.
* **Deletar Funcionário:** Remover um funcionário do sistema pelo nome.
* **Sair:** Encerrar o aplicativo.

## Conceitos Aplicados

Este projeto foi construído para demonstrar e aplicar alguns conceitos importantes de desenvolvimento de software:

* **Arquitetura em Camadas:** Organização do código em `Controller`, `Service` e `Repository` para separar responsabilidades.
* **Programação Orientada a Objetos (POO):** Utilização de classes e objetos, encapsulamento, e sobrescrita de métodos essenciais (`Equals`, `GetHashCode`).
* **Validação de Entrada:** Garantia da integridade dos dados inseridos pelo usuário.
* **LINQ:** Uso de consultas integradas à linguagem para manipular coleções de dados de forma eficiente.

## Como Usar

1.  Clone este repositório.
2.  Abra o projeto em seu ambiente de desenvolvimento C#.
3.  Execute a aplicação. Você verá o menu no console para interagir.
