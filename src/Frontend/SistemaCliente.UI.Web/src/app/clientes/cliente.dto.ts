import { Porte } from './enum/porte';

export interface Cliente{
  id?: number
  nomeEmpresa: string
  porte: Porte
}
