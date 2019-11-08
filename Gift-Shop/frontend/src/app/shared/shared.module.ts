import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { TranslateModule } from '@ngx-translate/core';
import {
  NgbPaginationModule,
  NgbDatepickerModule,
  NgbTimepickerModule,
  NgbProgressbarModule,
  NgbModalModule,
  NgbTypeaheadModule,
  NgbDateAdapter,
  NgbDateNativeAdapter,
  NgbDropdownModule
} from '@ng-bootstrap/ng-bootstrap';

import { FileComponent } from './components/file/file.component';
import { AutofocusDirective } from './directives/autofocus.directive';
import { EmailDirective } from './directives/email.directive';
import { TablesortDirective, TablesortColDirective } from './directives/tablesort.directive';
import { EnumPipe } from './pipes/enum.pipe';
import { YesNoPipe } from './pipes/yes-no.pipe';
import { PanelComponent } from './panel/panel.component';
import { TitleComponent } from './components/title/title.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { DatepickerComponent } from './components/datepicker/datepicker.component';
import { LayoutComponent } from './components/layout/layout.component';
import { VersionComponent } from './components/version/version.component';
import { DatetimepickerComponent } from './components/datetimepicker/datetimepicker.component';

import {
  MatFormFieldModule,
  MatInputModule,
  MatButtonModule,
  MatCheckboxModule,
  MatDialogModule,
  MatProgressSpinnerModule,
} from '@angular/material';

const imports = [
  CommonModule,
  FormsModule,
  ReactiveFormsModule,
  TranslateModule,
  NgbDatepickerModule,
  NgbTimepickerModule,
  NgbProgressbarModule,
  NgbModalModule,
  NgbTypeaheadModule,
  NgbDropdownModule,
  MatFormFieldModule,
  MatInputModule,
  MatButtonModule,
  MatCheckboxModule,
  MatDialogModule,
  MatProgressSpinnerModule,
];

const declarations = [
  FileComponent,
  PanelComponent,
  TitleComponent,
  PaginationComponent,
  DatepickerComponent,
  LayoutComponent,
  VersionComponent,
  DatetimepickerComponent,
  AutofocusDirective,
  EmailDirective,
  TablesortDirective,
  TablesortColDirective,
  EnumPipe,
  YesNoPipe,
];

@NgModule({
  declarations: [...declarations],
  imports: [
    ...imports,
    RouterModule,
    NgbPaginationModule,
  ],
  exports: [...declarations, ...imports],
  providers: [{provide: NgbDateAdapter, useClass: NgbDateNativeAdapter}]
})
export class SharedModule { }
