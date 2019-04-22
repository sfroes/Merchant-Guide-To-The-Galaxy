Solução Merchant's Guide to the Galaxy

Para a resolução do problema foi criado um Web API, para que desta forma fosse possível aproveitar a solução em qualquer tipo de aplicação. Tendo como resultado Rest.
A API foi desenvolvida usando:
- Visual Studio 2019
- Web API MVC
- C#
- .NET Framework 4.7.2
- Teste de unidade

Dependências básicas para poder rodar a aplicação. Para baixa-la basta utilizar o nugget ou dependendo da configuração do Visual Studio ao fazer o Build da aplicação ele se encarregará de faze-las.
Funcionalidades que podem ser utilizadas na API:
- Conversão de números romanos para números inteiros
- Conversão de números inteiros para números romanos
- Conversão do texto galactial levando em consideração os símbolos
- Conversão do texto galactial levando em consideração os metais

Varias validações foram levadas em consideração para a criação da API, tanto nas regras de conversão de números romanos, quanto as de números inteiros.
Validações estas que por consequência são levadas para os textos galacticais que usam símbolos baseados nos números romanos.
Como uma api pode ser testada utilizando o POSTMAN ou mesmo o browser fazendo o deployd da API pelo Visual Studio e chamando as funcionalidades como, por exemplo:

https://localhost:44341/api/InterGalactical/ConverterTextoGalactical/how much is pish tegj glob glob
https://localhost:44341/api/RomanosInteiros/ConverterRomanoInteiro/MCMIV
https://localhost:44341/api/InteirosRomanos/ConverterInteiroRomano/2706

Foi desenvolvido um frontend para consumo da API utilizando:
- HTML
- CSS
- Bootstrap
- Jquery

Para utiliza-la é somente deployd o WebAPI e preencher o local e a porta da maquina, Ex: localhost:44341, no campo indicado e escolher a função que deseja executar.

Por medida de segurança todos os browsers vem com protegidos com CORS Policy. Desta forma tem que se desabilitar a segurança no caso do browser Chrome utilizar o seguinte comando.
- Apertar as teclas Windows + R
- Colar o comando na janela: 
chrome.exe --user-data-dir="C://Chrome dev session" --disable-web-security
- Abrir a pagina HTML neste browser.

Todos os testes podem ser acompanhados no arquivo de EvidenciasTeste.docx



