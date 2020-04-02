import { NgModule } from "@angular/core";
import { SkFoldingCubeComponent } from "./sk-folding-cube.component";
import { MaskedSKFoldingCubeComponent } from "./masked-sk-folding-cube.component";
import { BrowserModule } from "@angular/platform-browser";
import { MSLoadingComponent } from "./ms-loading-icon.component";
import { ComponentInnerLoader } from "./component-inner-loader.component";

@NgModule({
    imports: [BrowserModule],
    declarations: [SkFoldingCubeComponent, ComponentInnerLoader, MaskedSKFoldingCubeComponent, MSLoadingComponent],
    exports: [SkFoldingCubeComponent, ComponentInnerLoader ,MaskedSKFoldingCubeComponent, MSLoadingComponent]
})
export class LoadersModule {}