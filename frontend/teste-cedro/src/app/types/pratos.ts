import { Base } from './base';
export interface Prato extends Base {
    nome: string;
    nomeRestaurante: string;
    id: number;
    restauranteId: number;
    preco: number;
}