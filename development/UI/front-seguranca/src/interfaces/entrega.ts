export interface Entrega {
  codigoInterno: string;
  dataEntrega: Date;
  idResponsavelBosch: number;
  idTransponder: number;
  idTransportadora: number;
  liberado: boolean;
  pesoEntrada: number;
  pesoSaida: number;
  placaCarro: string;
}
