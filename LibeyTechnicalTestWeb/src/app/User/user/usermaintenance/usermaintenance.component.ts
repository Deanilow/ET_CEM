import { Component, OnInit } from '@angular/core';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import swal from 'sweetalert2';
import { ActivatedRoute } from '@angular/router'; // Importar ActivatedRoute
import { Router } from '@angular/router'; // Importar Router
import { NgForm } from '@angular/forms';
import { UtilService } from 'src/app/core/service/libeyuser/util.service';
import { IDocumentType } from 'src/app/entities/DocumentType';
import { Region } from 'src/app/entities/Region';
import { Province } from 'src/app/entities/Province';
import { Ubigeo } from 'src/app/entities/Ubigeo';
@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css'],
})
export class UsermaintenanceComponent implements OnInit {
  user: LibeyUser | null = {};
  documentTypes: IDocumentType[] = [];
  region: Region[] = [];
  province: Province[] = [];
  ubigeo: Ubigeo[] = [];
  constructor(
    private userService: LibeyUserService,
    private utilService: UtilService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadDocumentTypes();
    this.loadRegion();
    const documentNumber = this.route.snapshot.paramMap.get('documentNumber');
    if (documentNumber) {
      this.loadUserData(documentNumber);
    } else {
      this.user = {};
    }
  }

  loadUserData(documentNumber: string): void {
    this.userService.Find(documentNumber).subscribe({
      next: (response) => {
        if (!response.status) {
          swal.fire('Error', response.message, 'error');
        } else {
          if (response.data == null) {
            this.user = {};
          } else {
            this.user = response.data;
            if (this.user.ubigeoCode?.length == 6) {
              this.user.regionCode = this.user.ubigeoCode.substring(0, 2);
              this.loadProvince(this.user.regionCode);
              this.user.provinceCode = this.user.ubigeoCode.substring(0, 4);
              this.onProvinciaChange(this.user.provinceCode);
              this.user.ubigeoCode = this.user.ubigeoCode;
            }
          }
        }
      },
      error: () => {
        swal.fire('Error', 'Error de conexión al servidor.', 'error');
      },
    });
  }

  loadDocumentTypes(): void {
    this.utilService.GetAllDocumentsType().subscribe({
      next: (response) => {
        if (response.status) {
          this.documentTypes = response.data;
        } else {
          swal.fire('Error', response.message, 'error');
        }
      },
      error: () => {
        swal.fire('Error', 'Error de conexión al servidor.', 'error');
      },
    });
  }

  loadRegion(): void {
    this.utilService.GetAllRegion().subscribe({
      next: (response) => {
        if (response.status) {
          this.region = response.data;
        } else {
          swal.fire('Error', response.message, 'error');
        }
      },
      error: () => {
        swal.fire('Error', 'Error de conexión al servidor.', 'error');
      },
    });
  }

  loadProvince(regionCode: string): void {
    this.utilService.FindProvince(regionCode).subscribe({
      next: (response) => {
        if (response.status) {
          this.province = response.data;
        } else {
          swal.fire('Error', response.message, 'error');
        }
      },
      error: () => {
        swal.fire('Error', 'Error de conexión al servidor.', 'error');
      },
    });
  }

  onProvinciaChange(provinceCode: string): void {
    this.utilService.FindUbigeo(provinceCode).subscribe({
      next: (response) => {
        if (response.status) {
          this.ubigeo = response.data;
        } else {
          swal.fire('Error', response.message, 'error');
        }
      },
      error: () => {
        swal.fire('Error', 'Error de conexión al servidor.', 'error');
      },
    });
  }

  Submit(form: NgForm) {
    if (form.valid) {
      if (this.user) {
        const documentNumberUpdated =
          this.route.snapshot.paramMap.get('documentNumber');
        if (documentNumberUpdated) {
          this.userService.Update(this.user).subscribe({
            next: (response) => {
              if (!response.status) {
                swal.fire('Error', response.message, 'error');
              } else {
                swal.fire(
                  'Success',
                  'Usuario Actualizado correctamente!',
                  'success'
                );

                setTimeout(() => {
                  this.router.navigate(['/user/list']);
                }, 2000);
              }
            },
            error: () => {
              swal.fire('Error', 'Error de conexión al servidor.', 'error');
            },
          });
        } else {
          this.userService.Create(this.user).subscribe({
            next: (response) => {
              if (!response.status) {
                swal.fire('Error', response.message, 'error');
              } else {
                swal.fire(
                  'Success',
                  'Usuario guardado correctamente!',
                  'success'
                );

                setTimeout(() => {
                  this.router.navigate(['/user/list']);
                }, 2000);
              }
            },
            error: () => {
              swal.fire('Error', 'Error de conexión al servidor.', 'error');
            },
          });
        }
      } else {
        swal.fire('Error', 'Datos del usuario son nulos.', 'error');
      }
    } else {
      form.control.markAllAsTouched();
    }
  }

  onRegionChange(regionCode: string): void {
    this.loadProvince(regionCode);
  }

  Limpiar() {
    this.user = {}
  }

  Volver() {
    this.router.navigate(['/user/list']);
  }
}
