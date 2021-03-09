import { Categoria } from './categoria.model';
import { Cartao } from './cartao.model';
import { Mes } from './mes.model';

export class Despesa {
    despesaId: number;
    cartaoId: number;
    cartao: Cartao;
    descricao: string;
    categoriaId: number;
    categoria: Categoria;
    valor: number;
    dia: number;
    mesId: number;
    mes: Mes;
    ano: number;
    usuarioId: number;
}
