import { Entrega } from './entrega';
import { Entregador } from './entregador';
export interface EntregaMotorista{
    id : number,
    entrega : Entrega,
    entregadores: Array<Entregador>,
}