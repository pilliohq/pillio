
export interface MedicationPlanWorkflowInfo {
  confirmationTenantId?: number;
  confirmationTenantName?: string;
  confirmationUserName?: string;
  confirmationDate?: string;
  approvalTenantId?: number;
  approvalUserName?: string;
  approvalDate?: string;
  deliveryTenantId?: number;
  deliveryTenantName?: string;
  deliveryUserName?: string;
  deliveryDate?: string;
  isCompleted?: boolean;
  notes?: string;
  moreInfo: WorkflowMoreInfo;
}

export interface WorkflowMoreInfo {
}
