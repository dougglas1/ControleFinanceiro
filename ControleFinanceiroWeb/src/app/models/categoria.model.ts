import { Tipo } from "./tipo.model";

export class Categoria {
    categoriaId: number;
    nome: string;
    icone: string;
    tipoId: number;
    tipo: Tipo;
}
