

1Dependecias

https://dotnet.microsoft.com/download/dotnet/5.0

Instalar el preview de VS 2019 

Abrrir la solucion instalar lo que te pida

Sin .net sdk 5 nada


1 Crear el proyecto

2 Crear el test (que servira para las dos cosas)

3 Agregar al proyecto destino  para que lo pille

  <ProjectReference Include="..\ToStringSourceGenerator\ToStringSourceGenerator.csproj"
                      OutputItemType="Analyzer"
                      ReferenceOutputAssembly="false"
     />

NO funciona en los tests asi que se genera un libreria nueva para las pruebas

# 1 generar un metodo toString()

Pasos seguidos

1 Generar sln

2 Generar proyecto AutoToString

3 Generar proyecto Types

4 Generar proyecto Tests

5 En el proyecto AutoToString generar codigo para emitir

6 Copiar las clases de utilidad del proyecto Minsk

7 Iterar todos los tipos y encontrar aquellos que tienen el atrributo correspondiente

8 Generar clase en memoria para hacer el autotostring

9 validar que la clase es parcial y generar un warning en caso de que no lo sea

10 Hacer test que valida el output


Siguiente paso es hacer el autotostrign dinamico

Validar

