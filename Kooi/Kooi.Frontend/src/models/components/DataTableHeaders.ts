import type { VDataTable } from 'vuetify/lib/labs/components.mjs';

type UnwrapReadonlyArrayType<A> = A extends Readonly<Array<infer I>>
    ? UnwrapReadonlyArrayType<I>
    : A;
type DT = InstanceType<typeof VDataTable>;
export type ReadonlyDataTableHeader = UnwrapReadonlyArrayType<DT['headers']>;

type DeepMutable<T> = { -readonly [P in keyof T]: DeepMutable<T[P]> }
export type DataTableHeader = DeepMutable<ReadonlyDataTableHeader>;