import { Entrega } from './entrega';
import { MotoristaAjudante } from './motoristaAjudante';
export interface EntregaMotorista{
    id : number,
    entrega : Entrega,
    entregadores: Array<MotoristaAjudante>,
}