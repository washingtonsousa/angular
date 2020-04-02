import { NgModule } from "@angular/core";
import { InfoBoxComponent } from "./InfoBox/infobox.component";
import { InfoBoxKeyValueLineComponent } from "./InfoBox/infobox-key-value-line.component";
import { ContentBoxComponent } from "./InfoBox/content-box.component";
import { CommonModule } from "@angular/common";
import { TextBoxComponent } from "./InfoBox/textbox.component";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CustomModalsModule } from "../custommodals/custommodals.module";

@NgModule({
imports: [CommonModule, BrowserAnimationsModule, CustomModalsModule],
exports: [InfoBoxComponent, TextBoxComponent, InfoBoxKeyValueLineComponent, ContentBoxComponent],
declarations: [InfoBoxComponent, TextBoxComponent, InfoBoxKeyValueLineComponent, ContentBoxComponent]
})
export class VisualComponentsModule {
}