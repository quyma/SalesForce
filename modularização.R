## FGV-Management - 2S2020
## Análise de Mídias Sociais e Mineração de Texto - Aula 3
## Prof. Eduardo de Rezende Francisco
## Data: 30/Novembro/2020

## Exemplo de SNA - Social Network Analysis - Rede ONE MODE

# Extensões para Análise de Redes
#(devem ser previamente baixadas no CRAN do R)

install.packages("network")
library(network)
install.packages("sna")
library(sna)
install.packages("rgl")
library(rgl)
install.packages("igraph")
library(igraph)

# Trabalha a partir de uma rede aleatória
redeGlobal <- read.table("C:/Users/Carrefour Cambuci/Desktop/MBA/Análise de Mídias Sociais e Mineração de texto/net/network.csv",header=TRUE,sep = ";", dec=",")
rede <- read.table("C:/Users/Carrefour Cambuci/Desktop/MBA/Análise de Mídias Sociais e Mineração de texto/net/01p2T000000J6kbQAC-EK6_DadoCadastralCommandTest-ApexClass.csv",header=TRUE,sep = ";", dec=",")



# Adaptando o data.frame rede para que possa servir para a montagem da rede
gredeGlobal <- redeGlobal[,2:2780]
rownames(gredeGlobal) <- redeGlobal[,1]


 




# Construindo a rede a partir da matriz de relações (0 e 1)
gplot(redeGlobal,displaylabels = FALSE,displayisolates=TRUE)

#Funcionalida especifica
gplot(rede,displaylabels = TRUE,displayisolates=FALSE)



gplot(grede,gmode="graph",displaylabels = TRUE)
gplot(grede,gmode="graph",displaylabels = TRUE,edge.col="gray",usearrows=FALSE)

# Explorando a rede
degree(grede,gmode="graph",cmode="indegree")
closeness(grede,gmode="graph")
betweenness(grede,gmode="graph")

# Aprimorando a representação da rede
gplot(grede,gmode="grede",displaylabels = TRUE,
      edge.col="gray",usearrows=FALSE,vertex.cex=degree(grede,gmode="graph",cmode="indegree")/3)

gplot(grede,gmode="grede",displaylabels = TRUE,
      edge.col="gray",usearrows=FALSE,label=degree(grede,gmode="graph",cmode="indegree"))

gplot(grede,gmode="grede",displaylabels = TRUE,
      edge.col="gray",usearrows=FALSE,vertex.cex=closeness(grede,gmode="graph")*2)

gplot(grede,gmode="grede",displaylabels = TRUE,
      edge.col="gray",usearrows=FALSE,label=round(closeness(grede,gmode="graph"),digits=2))

gplot(grede,gmode="grede",displaylabels = TRUE,
      edge.col="gray",usearrows=FALSE,vertex.cex=betweenness(grede,gmode="graph")/3+1)

gplot(grede,gmode="grede",displaylabels = TRUE,
      edge.col="gray",usearrows=FALSE,label=betweenness(grede,gmode="graph"))

# Grand finale... para impressionar
gplot3d(grede,displaylabels = TRUE)

# Comando útil para explorar redes
# Gera redes aleatórias
grede2 <- rgraph(10)
grede2

# Interprete as métricas de centralidade de grau, proximidade e intermediação
# para a rede da variável grede
