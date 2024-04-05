# DesafioBackEnd
**Fluxo**
Verifique a string de conexão que está em appsettings.json. E adeque-se para a sua, caso necessário.
update-database(caso estiver utilizando visual studio, apenas abrir o console gerenciador de pacotes e dar esse comando para criar o banco de dados).
Eu criei dados fixos para a tabela Measurement.

Crie seu usuario, após isso faça o login. e coloque o jwtToken no autenticador bearer.
assim você tem acesso a todos os outros endpoints.
Criar um device: Manufacturer tem q ser PredictWeather, commands.Name tem q ser get_rainfall_intensity e em parameters.name coloque algum desses valores:
São Paulo
Rio de Janeiro
Brasília
Salvador
Fortaleza
Curitiba
Recife
Manaus
Porto Alegre
Belém
Goiânia
Florianópolis
Vitória
Natal
João Pessoa
Campo Grande
Teresina
Cuiabá
São Luís
Maceió.

1. **Arquitetura em camadas**: O projeto adotou uma arquitetura em camadas, com separação clara entre a camada de aplicação, infraestrutura e domínio. Isso facilita a manutenção, escalabilidade e testabilidade do código.
2. **Uso de DTOs**: Foram utilizados DTOs (Data Transfer Objects) para transferência de dados entre as camadas da aplicação. Isso ajuda a separar a lógica de negócios das responsabilidades de apresentação e comunicação.
3. **Injeção de dependência**: A injeção de dependência foi utilizada para fornecer uma forma flexível e desacoplada de gerenciar as dependências entre os diferentes componentes da aplicação.
4. **Validação de dados**: Foram implementados mecanismos de validação de dados nas entidades do domínio para garantir a integridade dos dados e evitar inconsistências no sistema.
5. **Uso de AutoMapper**: O AutoMapper foi utilizado para mapear objetos de domínio para DTOs e vice-versa, reduzindo a necessidade de código repetitivo e simplificando o processo de mapeamento.
6. **Tratamento de exceções**: O projeto implementou um tratamento adequado de exceções, lançando e capturando exceções de forma apropriada e fornecendo mensagens de erro claras para os usuários.
7. **Segurança**: A autenticação de usuários foi implementada para proteger os dados sensíveis e restringir o acesso apenas a usuários autorizados.

Sugestões de melhorias e avanços futuros:

1. **Implementação de testes automatizados**: Adicionar testes unitários e de integração para garantir a qualidade do código e facilitar futuras atualizações e manutenções.
2. **Melhorias na segurança**: Avaliar e implementar medidas adicionais de segurança, como criptografia de dados(Senha do usuario).
3. **Otimização de desempenho**: Identificar e otimizar áreas do código que podem estar causando gargalos de desempenho, visando melhorar a responsividade e eficiência do sistema.
4. **Implementação de cache**: Utilizar técnicas de cache para armazenar em cache dados frequentemente acessados e reduzir a carga no banco de dados.
7. **Escalabilidade**: Planejar e implementar estratégias de escalabilidade para lidar com um aumento no número de usuários e volume de dados.
8. **Monitoramento e análise de logs**: Implementar ferramentas de monitoramento e análise de logs para acompanhar o desempenho e identificar problemas de forma proativa.
9. **Azure Data Factory**: Uma possivel solução para a atualização dos dados de measurement. Agora os dados estão fixos, apenas para termos uma base do meu pensamento. Mas em uma aplicação real seria necessario uma base de dados q ficasse em constante atualização nas previsões de chuva. E o azure data factory funciona bem nesse sentido.(Nunca utilizei ele, apenas foi uma ideia que conversamos no meu emprego anterior que teria o mesmo comportamento).
10. **Enums**: Utilizar enums nas pesquisas de fabricando e comandos, é uma boa prática utilizá-los nessa situação e n utilizar strings como estou fazendo.

Explicação da modelagem do banco de dados e do que eu entendi do desafio.
O que eu entendi do desafio foi. 
Ter funcionalidade de usuarios com login. Adotei uma solução simples para isso utilizando o jwtBearer para autenticar o usuario e assim fazer com q os endpoints só sejam acessados após isso.
Ter funcionalidade de "Crud" de dispositivos. Nessa parte eu fiz a seguinte modelagem no banco de dados. 1 device, pode ter 1 ou n commandos com 1 ou n parametros. E Pode ter vários devices com o mesmo measurementId. Hoje a inserção e update estão amarrados a essa regra:deviceDTO.Manufacturer == "PredictWeather" && command.Name == "get_rainfall_intensity".

Exemplo de inserção:{
  "identifier": "string",
  "description": "string",
  "manufacturer": "string",
  "url": "string",
  "commands": [
    {
      "name": "string1",
      "description": "string",
      "parameters": [
        {
          "name": "Belém",
          "description": "string"
        },
        {
          "name": "Goiânia",
          "description": "string"
        },
        {
          "name": "Florianópolis",
          "description": "string"
        }
      ]
    },
    {
      "name": "string2",
      "description": "string",
      "parameters": [
        {
          "name": "São Paulo",
          "description": "string"
        },
        {
          "name": "Fortaleza",
          "description": "string"
        },
        {
          "name": "Recife",
          "description": "string"
        }
      ]
    },
    {
      "name": "string3",
      "description": "string",
      "parameters": [
        {
          "name": "Curitiba",
          "description": "string"
        },
        {
          "name": "Manaus",
          "description": "string"
        },
        {
          "name": "Porto Alegre",
          "description": "string"
        }
      ]
    }
  ]
}
assim a gente consegue rasterar pela tabela commands por exemplo oq a gente quiser.

e a tabela measurement seria uma tabela de "pesquisa".
