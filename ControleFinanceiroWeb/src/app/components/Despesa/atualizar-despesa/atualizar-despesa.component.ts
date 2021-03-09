import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { MesService } from './../../../services/mes.service';
import { CategoriasService } from './../../../services/categorias.service';
import { CartoesService } from './../../../services/cartoes.service';
import { DespesasService } from './../../../services/despesas.service';
import { Mes } from './../../../models/mes.model';
import { Categoria } from 'src/app/models/categoria.model';
import { Observable } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { Despesa } from 'src/app/models/despesa.model';
import { Cartao } from 'src/app/models/cartao.model';

@Component({
  selector: 'app-atualizar-despesa',
  templateUrl: './atualizar-despesa.component.html',
  styleUrls: ['../listagem-despesas/listagem-despesas.component.css'],
})
export class AtualizarDespesaComponent implements OnInit {
  despesa: Observable<Despesa>;
  valorDespesa: number;
  formulario: any;
  cartoes: Cartao[];
  categorias: Categoria[];
  meses: Mes[];
  erros: string[];
  despesaId: number;
  usuarioId: string = localStorage.getItem('UsuarioId');

  constructor(
    private despesasService: DespesasService,
    private cartoesService: CartoesService,
    private categoriasService: CategoriasService,
    private mesesService: MesService,
    private router: Router,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.erros = [];
    this.despesaId = this.route.snapshot.params.id;

    this.cartoesService
      .BuscarCartoesPorUsuarioId(this.usuarioId)
      .subscribe((resultado) => {
        this.cartoes = resultado;
      });

    this.categoriasService
      .FiltrarCategoriasDespesas()
      .subscribe((resultado) => {
        this.categorias = resultado;
      });

    this.mesesService.BuscarTodos().subscribe((resultado) => {
      this.meses = resultado;
    });

    this.despesasService
      .BuscarDespesaPorId(this.despesaId)
      .subscribe((resultado) => {
        this.valorDespesa = resultado.valor;

        this.formulario = new FormGroup({
          despesaId: new FormControl(resultado.despesaId),
          cartaoId: new FormControl(resultado.cartaoId, [Validators.required]),
          descricao: new FormControl(resultado.descricao, [
            Validators.required,
            Validators.minLength(1),
            Validators.maxLength(50),
          ]),
          categoriaId: new FormControl(resultado.categoriaId, [
            Validators.required,
          ]),
          valor: new FormControl(resultado.valor, [Validators.required]),
          dia: new FormControl(resultado.dia, [Validators.required]),
          mesId: new FormControl(resultado.mesId, [Validators.required]),
          ano: new FormControl(resultado.ano, [Validators.required]),
          usuarioId: new FormControl(resultado.usuarioId),
        });
      });
  }

  get propriedade() {
    return this.formulario.controls;
  }

  EnviarFormulario(): void {
    this.erros = [];
    const despesa = this.formulario.value;
    this.despesasService.AlterarDespesa(this.despesaId, despesa).subscribe(
      (resultado) => {
        this.router.navigate(['despesas/listagemdespesas']);
        this.snackBar.open(resultado.mensagem, null, {
          duration: 2000,
          horizontalPosition: 'right',
          verticalPosition: 'top',
        });
      },
      (err) => {
        if (err.status === 400) {
          for (const campo in err.error.errors) {
            if (err.error.errors.hasOwnProperty(campo)) {
              this.erros.push(err.error.errors[campo]);
            }
          }
        }
      }
    );
  }

  VoltarListagem(): void {
    this.router.navigate(['despesas/listagemdespesas']);
  }
}