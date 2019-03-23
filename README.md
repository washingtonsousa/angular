# HR Solution - Web API

Esta aplicação não dispõe de interface do usuário embarcada, você deve utilizar o Front End Angular na pasta de nome que referencia o mesmo.

## Desenvolvimento Angular

Execute o comando `npm install` no node.JS para instalar os pacotes.

Para desenvolvimento Front End utilize o node.JS e o gulp, o comando principal é o `npm run gulp watch-compile` para compilação scss assistida e `npm run gulp compile-deploy`
para compilação singular manual. Aviso que este mecanismo tem um delay quando executado junto com o modo de desenvolvimento do angular, então execute duas vezes o comando singular ou salve o mesmo arquivo duas vezes para carregar no navegador as alterações realizadas.

Mais detalhes de como utilizar o Front end Angular abra a pasta e leia o README.MD dentro da pasta da aplicação Angular.

O Comando padrão para subir um servidor local para testes do Angular é o `npm run ng serve --open` 

## Produção/Desenvolvimento Web API

Siga as intruções contidas no documento Word dentro da pasta Docs para montar o seu ambiente.

## Produção Angular

Execute o comando `npm install` no node.JS para instalar os pacotes.

Configure as variaveis de ambiente da aplicação seguindo a documentação word contida na pasta Docs.

Execute o comando `npm run ng build --prod`, caso precisar  definir um subdiretório utilize o parametro `--base-href="<subdiretorio>"`

Os arquivos compilados estarão na pasta JS dentro do diretório da aplicação Front End.

### Desenvolvido por Washington de Sousa Meneses - FullStack Developer

