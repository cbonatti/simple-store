import { ProductCommandBase } from "./product-base.command";

export class UpdateProductCommand extends ProductCommandBase {
    id: string;
}