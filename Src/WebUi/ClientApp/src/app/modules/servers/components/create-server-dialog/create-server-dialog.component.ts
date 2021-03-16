import {Component, NgModule, OnInit} from '@angular/core';
import {MatDialogModule, MatDialogRef} from "@angular/material/dialog";
import {MatButtonModule} from "@angular/material/button";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {CreateServerRequest} from "../../../../core/models/servers/requests/create-server-request.model";
import {ServersService} from "../../../../core/services/servers/servers.service";
import {NGXLogger} from "ngx-logger";

@Component({
  selector: 'app-create-server-dialog',
  templateUrl: './create-server-dialog.component.html',
  styleUrls: ['./create-server-dialog.component.scss']
})
export class CreateServerDialogComponent implements OnInit {
  public formGroup: FormGroup;
  private _saving: boolean;

  constructor(private _formBuilder: FormBuilder,
              private _serversService: ServersService,
              private _logger: NGXLogger,
              private _dialogRef: MatDialogRef<CreateServerDialogComponent>) { }

  ngOnInit(): void {
    this.formGroup = this._formBuilder.group({
      serverName: ['', Validators.required]
    });
  }

  onSubmit(): void {
    this._saving = true;
    const request: CreateServerRequest = {serverName: this.formGroup.get('serverName').value};
    this._serversService.createServer(request)
      .subscribe(s => {
        this._logger.info('Server Created!', s);
        this._saving = false;
        this._dialogRef.close();
      });
  }

}

@NgModule({
  imports: [MatDialogModule, MatButtonModule, MatFormFieldModule, MatInputModule, ReactiveFormsModule],
  declarations: [CreateServerDialogComponent]
})
export class CreateServerDialogModule {}
