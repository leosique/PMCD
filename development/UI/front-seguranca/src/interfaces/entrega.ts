export interface Entrega {
  id: number,
  codigoInterno: string,
  dataEntrega: Date,
  idResponsavelBosch: number,
  idTransponder: number,
  idTransportadora: number,
  liberado: boolean,
  notaFiscal: string,
  pesoEntrada: number,
  pesoSaida: number,
  placaCarro: string,
}


